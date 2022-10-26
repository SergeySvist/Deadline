using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SmartSocket
{
    public class Core
    {
        private Socket localSocket;
        private IPEndPoint endPoint;
        //private List<Socket> remoteSockets;
        public event EventHandler<CoreMessageEventArgs> MessageReceived;
        public Core(IPAddress ip, int port)
        {
            localSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(ip, port);
            //remoteSockets = new List<Socket>();
        }

        public string Listening()
        {
            localSocket.Bind(endPoint);
            localSocket.Listen(4096);

            
            while (true)
            {
                Socket remoteSocket = localSocket.Accept(); // BLOCKING

                byte[] buffer = new byte[4096];
                int byteCount = 0;
                string input = String.Empty;

                do
                {
                    byteCount = remoteSocket.Receive(buffer);
                    input += Encoding.UTF8.GetString(buffer, 0, byteCount);
                } while (remoteSocket.Available > 0);

                MessageReceived.Invoke(this, new CoreMessageEventArgs(input, remoteSocket));

                remoteSocket.Shutdown(SocketShutdown.Both);
                remoteSocket.Close();
            }
        }

        public void Send(Socket socket, string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
        }

        public void MassSend(List<Socket> sockets, string message)
        {
            foreach(Socket socket in sockets)
                Send(socket, message);
        }
    }
}