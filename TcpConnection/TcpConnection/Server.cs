using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpConnection
{
    public static class Server
    {
        public static void OpenPort()
        {
            try
            {
                var socketlisteners = new Socket[2];
                Console.Write("Введите ip-адрес сервера: ");
                var iphostentry = Dns.GetHostEntry(Console.ReadLine());
                var ipaddress = iphostentry.AddressList[0];
                for (int i = 0; i < 2; i++)
                {
                    Console.Write("Введите открываемый порт: ");
                    var ipEndPoint = new IPEndPoint(ipaddress, int.Parse(Console.ReadLine()));
                    var socketAccept = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    socketAccept.Bind(ipEndPoint);
                    socketAccept.Listen(5);
                    Console.WriteLine("Ожидание соединения...");
                    socketlisteners[i] = socketAccept.Accept();
                    Console.WriteLine("Соединение установлено");
                }
                Console.Write("Введите адреса порта, на которое будет отправлено сообщение: ");
                var port = int.Parse(Console.ReadLine());
                var ipEndpoint = new IPEndPoint(ipaddress, port);
                var socketaccept = new Socket(ipEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socketaccept.Bind(ipEndpoint);
                socketaccept.Listen(5);
                var socketsender = socketaccept.Accept();
                Console.WriteLine("Порт для отправки сообщений подключен");
                while (true)
                {
                    foreach (var i in socketlisteners)
                    {
                        byte[] bytes = new byte[1024];
                        int bytesRec = i.Receive(bytes);
                        var data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                        Console.WriteLine("Полученное сообщение с порта {0}: " + data, ipEndpoint.Port);
                        bytes = Encoding.UTF8.GetBytes(data);
                        socketsender.Send(bytes);
                        Console.WriteLine("Сообщение отправлено на порт {0}", port);
                    }
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
