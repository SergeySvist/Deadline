using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartSocket
{
    public class CoreMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public CoreMessageEventArgs(string message)
        {
            Message = message;
        }
    }

}
