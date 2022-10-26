using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BetterSocket
{
    public class BetterSocket
    {
        Dictionary<Command, Action> actions;

        public BetterSocket()
        {
            actions = new Dictionary<Command, Action>();
        }

        public void Listening(IPAddress ip, int port)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            socket.Bind(endPoint);
            socket.Listen(4096);

            Task.Run(() =>
            {
                while (true)
                {
                    Socket remoteSocket = socket.Accept(); // BLOCKING

                    byte[] buffer = new byte[4096];
                    int byteCount = 0;
                    string input = String.Empty;

                    do
                    {
                        byteCount = remoteSocket.Receive(buffer);
                        input += Encoding.UTF8.GetString(buffer, 0, byteCount);
                    } while (remoteSocket.Available > 0);
                    
                    //запуск обработчика на действие по определенной команде 
                    var command = Command.Deserialize(input);
                    actions[command]?.Invoke();

                    remoteSocket.Shutdown(SocketShutdown.Both);
                    remoteSocket.Close();
                }
            });

        }

        public void AddHandler(Command command, Action action)
        {
            actions.Add(command, action);
        }
        
    }
}