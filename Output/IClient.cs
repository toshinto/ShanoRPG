using IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public interface IClient
    {

        event Action<Command, byte[]> OnSpecialAction;

        /// <summary>
        /// Gets the current movement state of the player. 
        /// </summary>
        /// <returns></returns>
        MovementState MovementState { get; }


    }
}
