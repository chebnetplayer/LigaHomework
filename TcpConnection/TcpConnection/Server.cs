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
                var IPaddres = IPAddress.Parse(Console.ReadLine());           
                Console.Write("Введите открываемый порт: ");
                var ipEndPoint = new IPEndPoint(IPaddres, int.Parse(Console.ReadLine()));
                var socketAccept = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socketAccept.Bind(ipEndPoint);
                socketAccept.Listen(5);
                Console.WriteLine("Ожидание соединения...");
                socketlisteners[0] = socketAccept.Accept();
                Console.WriteLine("Соединение установлено");             
                Console.Write("Введите адреса порта, на которое будет отправлено сообщение: ");
                var ipEndpoint = new IPEndPoint(IPAddress.Parse("192.168.1.193"), int.Parse(Console.ReadLine()));
                var socketaccept = new Socket(ipEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socketaccept.Connect(ipEndpoint);
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
                        socketaccept.Send(bytes);
                        Console.WriteLine("Сообщение отправлено на порт ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                OpenPort();
            }
        }     
    }
}
