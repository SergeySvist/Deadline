using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SmartSocket
{
    class SmartSocket
    {
        private Dictionary<string, Action<object, EventArgs>> commands;
        ICore networkCore;

        public SmartSocket(string ip, int port)
        {
            commands = new Dictionary<string, Action<object, EventArgs>>();
            networkCore = new Core(IPAddress.Parse(ip), port);
            networkCore.MessageReceived += MessageReceiveHandler;
            networkCore.ClientConnected += ClientConnectedHandler;
        }

        private void ClientConnectedHandler(object? sender, EventArgs e)
        {

        }

        public void MessageReceiveHandler(object? sender, CoreMessageEventArgs e)
        {

        }
        
        public void Emmit()
        {

        }

        public void MassEmit()
        {

        }
    }
}
