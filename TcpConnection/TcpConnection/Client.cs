using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpConnection
{
    class Client
    {
        public static void SendMessage()
        {
            try
            {
                Console.Write("Введите ip-адрес сервера: ");
                //var iphostentry = Dns.GetHostEntry(Console.ReadLine());
                var ipaddress = IPAddress.Parse("192.168.1.193");
                Console.Write("Введите подключаемый порт: ");
                var ipEndpoint = new IPEndPoint(ipaddress, int.Parse(Console.ReadLine()));
                var socketclient = new Socket(ipEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socketclient.Connect(ipEndpoint);
                Console.WriteLine("Соединение установлено");
                while (true)
                {
                    Console.Write("Введите сообщение для отправки: ");
                    string message = Console.ReadLine();
                    byte[] msg = Encoding.UTF8.GetBytes(message);
                    int bytesSent = socketclient.Send(msg);
                    Console.WriteLine("Сообщение отправлено");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                SendMessage();
            }

        }
        public static void GetMessage()
        {
            try
            {
                Console.Write("Введите ip-адрес сервера: ");
                var ipaddress = IPAddress.Parse("192.168.1.134");
                Console.Write("Введите подключаемый порт: ");
                var ipEndpoint = new IPEndPoint(ipaddress, int.Parse(Console.ReadLine()));
                var socketclient = new Socket(ipEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socketclient.Connect(ipEndpoint);
                Console.WriteLine("Соединение установлено");
                while (true)
                {
                    byte[] msg = new byte[1024];
                    int bytesRec = socketclient.Receive(msg);
                    Console.WriteLine("Полученное сообщение: " + Encoding.UTF8.GetString(msg, 0, bytesRec));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                SendMessage();
            }
        }
    }
}

        