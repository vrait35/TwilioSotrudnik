using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLib;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
namespace ITwilio
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ConsoleKeyInfo key;
            int y = 1;
            Employess employess = null;
            bool isKod = false;
            while (true)
            {
                Show(ref y);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow) { if (y < 4) y++; }
                else if (key.Key == ConsoleKey.UpArrow) { if (y > 1) y--; }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (y == 1)
                    {
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (employess is null) employess = new Employess();
                        Employe ebuf = new Employe();
                        Console.Write("введите имя  ");
                        ebuf.FirstName = Console.ReadLine();
                        Console.Write("введите фамилию  ");
                        ebuf.LastName = Console.ReadLine();
                        Console.Write("введите должность  ");
                        ebuf.Dol = Console.ReadLine();
                        Console.Write("введите номер телефона  ");
                        string bufnumberPhone = Console.ReadLine();
                        
                        // Find your Account Sid and Token at twilio.com/console
                        const string accountSid = "ACcb97c83a29ffe6aa6109a14a350e6ea7";
                        const string authToken = "0ad183c0a412d2498ac1e2b0042930cf";

                        TwilioClient.Init(accountSid, authToken);
                        Random rnd = new Random();
                        string mesage = rnd.Next(1000, 9999).ToString();
                        Console.WriteLine("Вам пришло СМС 4х код для проверки: " + mesage);
                        var message = MessageResource.Create(
                            body: mesage,
                            from: new PhoneNumber("+18507546379"),
                            to: new PhoneNumber("+77082195258")
                        );
                        Console.WriteLine(message.Sid);
                        while (!isKod)
                        {
                            Console.WriteLine("введите код проверки");

                            string chekKod = Console.ReadLine();

                            if (chekKod != mesage) Console.WriteLine("Не правильный код");
                            else isKod = true;
                        }
                        isKod = false;
                        ebuf.NumberPhone = bufnumberPhone;
                        employess.Add(ebuf);
                        Console.Clear();
                    }
                    else if (y == 2)
                    {
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (!(employess is null))
                            employess.Show();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (y == 3)
                    {
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (employess == null) break;
                        Employe ebuf = new Employe();
                        Console.Write("введите имя  ");
                        ebuf.FirstName = Console.ReadLine();
                        Console.Write("введите фамилию  ");
                        ebuf.LastName = Console.ReadLine();
                        Console.Write("введите должность  ");
                        ebuf.Dol = Console.ReadLine();
                        Console.Write("введите номер телефона  ");
                        ebuf.NumberPhone = Console.ReadLine();
                        employess.Delete(ebuf);
                    }
                    else if (y == 4)
                    {
                        Environment.Exit(0);
                    }
                   

                }
            }
        }


        public static void Show(ref int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (y == 1) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 1);
            Console.Write("Добавить");
            if (y == 2) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 2);
            Console.Write("Показать всех");
            if (y == 3) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 3);
            Console.Write("Удалить сотрудника");           
            if (y == 4) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 4);
            Console.Write("Выйти");            
        }



    }
}
