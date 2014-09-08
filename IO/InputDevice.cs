using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public interface InputDevice
    {
        event Func<InputCommand, int> OnInput;

        void RegisterInput(InputCommand cmd, int p);
    }
}
