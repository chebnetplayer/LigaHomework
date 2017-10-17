using System;
using System.Collections.Generic;


namespace TcpConnection
{
    class TcpConnection
    {
        public static void Main()
        {
            Console.WriteLine("Команда -open для создания сервера" +Environment.NewLine+
                "-get для получения сообщений" + Environment.NewLine +
                "-send для отправки сообщений");
            CommandRun(Console.ReadLine());
            Main();
        }
        static void CommandRun(string cmd)
        {
            switch (cmd)
            {
                case "-open":
                    {
                        Server.OpenPort();
                        break;
                    }
                case "-send":
                    {
                        Client.SendMessage();
                        break;
                    }
                case "-get":
                    {
                        Client.GetMessage();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Некорректный ввод!!!Введите правильно!");
                        Main();
                        break;
                    }
            }
        }
    }
}
