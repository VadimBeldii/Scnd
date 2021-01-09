using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp30
{
    class Program
    {
        static AutoResetEvent waitHandler = new AutoResetEvent(true); //  создаем хандлепр для синхронизации потокво
        static ConsoleKey Key;
        static string str = string.Empty;
        static void Main(string[] args)
        {
           
            Thread thread = new Thread(Print); // Инициализируем новый поток , который будет выполнять метод
            str = Console.ReadLine();
            thread.Start(); // Запускаем поток
            while (true)
            {
                Key = Console.ReadKey().Key;
                if (Key == ConsoleKey.Enter)
                {
                     str = Console.ReadLine();
                    Key = default;
                    waitHandler.Set();                             
                }
            }
        }

        static void Print() // Метод для вывода на консоль текста
        {           
            Console.Clear();
            do
            {
                if (Key == ConsoleKey.Enter)
                {
                    waitHandler.WaitOne();
                }
                Console.WriteLine(str);
                Thread.Sleep(1000);               
            } while (true);
            
        }
    }



    

}
