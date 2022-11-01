using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartSocket
{
    internal interface ICore
    {
        public event EventHandler<CoreMessageEventArgs> MessageReceived;
        public event EventHandler ClientConnected;

        public void Listening();
        public void Send(Socket socket, string message);
        public void MassSend(List<Socket> sockets, string message);

    }

}
