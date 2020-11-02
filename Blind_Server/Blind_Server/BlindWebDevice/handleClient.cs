using System;
using System.Text; // Encoding
using System.Threading;
using System.Data; // 
using System.Net; // network 관련
using System.Net.Sockets; // 소켓
using System.Collections.Generic;

namespace Blind_Server.BlindWebDevice
{
    class handleClient
    {
        TcpClient clientSocket = null;
        public Dictionary<TcpClient, string> ClientList = null;

        public void StartClient(TcpClient clientSocket, Dictionary<TcpClient, string> ClientList)
        {
            this.clientSocket = clientSocket;
            this.ClientList = ClientList;

            Thread t_hanlder = new Thread(doChat);
            t_hanlder.IsBackground = true;
            t_hanlder.Start();
        }

        public delegate void MessageDisplayHandler(string message, string user_name);
        public event MessageDisplayHandler OnReceived;

        public delegate void DisconnectedHandler(TcpClient clientSocket);
        public event DisconnectedHandler OnDisconnected;

        private void doChat()
        {
            NetworkStream stream = null;
            try
            {
                byte[] buffer = new byte[1024];
                string msg = string.Empty;
                int bytes = 0;
                int MessageCount = 0;

                while (true)
                {
                    MessageCount++;
                    stream = clientSocket.GetStream();
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    msg = Encoding.Unicode.GetString(buffer, 0, bytes);
                    msg = msg.Substring(0, msg.IndexOf("$"));

                    if (OnReceived != null)
                        OnReceived(msg, ClientList[clientSocket].ToString());
                }
            }
            catch (SocketException se)
            {
                if (clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);

                    clientSocket.Close();
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                if (clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);

                    clientSocket.Close();
                    stream.Close();
                }
            }
        }

    }
}
