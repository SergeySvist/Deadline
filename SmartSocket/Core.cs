using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SmartSocket
{
    public class Core : ICore
    {
        private Socket localSocket;
        private IPEndPoint endPoint;
        //private List<Socket> remoteSockets;
        public event EventHandler<CoreMessageEventArgs> MessageReceived;
        public event EventHandler ClientConnected;

        public Core(IPAddress ip, int port)
        {
            localSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(ip, port);
            //remoteSockets = new List<Socket>();
        }

        public void ConnectAndListen(IPAddress ip, int port)
        {
            if (!localSocket.Connected)
            {
                IPEndPoint serverEndPoint = new IPEndPoint(ip, port);
                localSocket.Connect(serverEndPoint);
                Task.Run(() => Listening());
            }
        }

        private void DecodeStreamData(Socket remoteSocket)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    byte[] buffer = new byte[4096];
                    int byteCount = 0;
                    string input = String.Empty;

                    do
                    {
                        byteCount = remoteSocket.Receive(buffer);
                        input += Encoding.UTF8.GetString(buffer, 0, byteCount);
                    } while (remoteSocket.Available > 0);

                    MessageReceived.Invoke(remoteSocket, new CoreMessageEventArgs(input));
                }
            });
        }

        public void Listening()
        {
            if (!localSocket.Connected)
            {
                localSocket.Bind(endPoint);
                localSocket.Listen(4096);

                while (true)
                {
                    Socket remoteSocket = localSocket.Accept(); // BLOCKING
                    ClientConnected.Invoke(remoteSocket, null);


                    DecodeStreamData(remoteSocket);

                    //    remoteSocket.Shutdown(SocketShutdown.Both);
                    //    remoteSocket.Close();
                }
            }
            else
            {
                Socket remoteSocket = localSocket;
                DecodeStreamData(remoteSocket);
            }
        }

        public void ServerSend(string message)
        {
            Send(localSocket, message);
        }

        public void Send(Socket socket, string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
        }

        public void MassSend(List<Socket> sockets, string message)
        {
            foreach (Socket socket in sockets)
                Send(socket, message);
        }

        public void CloseConnection()
        {
            localSocket.Close();
        }
    }
}