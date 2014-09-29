using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using IO;

namespace Network
{
    /// <summary>
    /// NetworkManagers create these when a player connects so they can be added to an engine. 
    /// Objects of this type read data as it is received from the remote client and 
    /// raise the appropriate events for the engine to consume. 
    /// </summary>
    public class NetworkClient : IClient, IDisposable
    {
        const int MessageSize = 4;
        const int BufferSize = MessageSize * 4;    //a bit larger than readsize

        public readonly Socket Socket;

        readonly byte[] buffer = new byte[BufferSize];
        private int bytesRead = 0;


        public NetworkClient(Socket sock)
        {
            this.Socket = sock;

            Socket.BeginReceive(buffer, bytesRead, MessageSize, SocketFlags.None, receiveCallback, null);
        }

        private void receiveCallback(IAsyncResult ar)
        {
            var bytesReadNow = Socket.EndReceive(ar);
            
            //messages are coded as follows:
            //2 bytes command
            //2 bytes message length
            //message
            if (bytesRead < 4)
            {
                return;
            }

            //get the message
            var msgCode = BitConverter.ToInt16(buffer, 0);
            var msgParams = buffer; //TODO: fucking fix

            parseMessage((Command)msgCode, msgParams);

            //start listening again
            bytesRead = bytesReadNow;
            Socket.BeginReceive(buffer, bytesRead, MessageSize, SocketFlags.None, receiveCallback, null);
        }

        private void parseMessage(Command c, byte[] p)
        {
            switch (c)
            {
                case Command.MovementX:
                    state.XDirection = Math.Sign(p.First());
                    break;
                case Command.MovementY:
                    state.YDirection = Math.Sign(p.First());
                    break;
                case Command.Ability:
                    if (OnSpecialAction != null)
                        OnSpecialAction(c, p);
                    break;
            }
        }


        private MovementState state = new MovementState();

        //Interface members
        public MovementState MovementState
        {
            get { return state; }
        }

        public event Action<Command, byte[]> OnSpecialAction;

        public void Dispose()
        {
            Socket.Dispose();
        }
    }
}
