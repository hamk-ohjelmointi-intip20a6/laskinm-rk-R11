using System;

namespace jokuvitunluuppi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Käyttäjän valinta
            while (true)
            {
                Console.WriteLine("Anna käyttäjänimi");
                string Kayttaja = Console.ReadLine();
                int Valinta;
                if (Kayttaja == "Admin")
                {
                    Console.WriteLine("Anna salasana");
                    string Salasana = "";
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    while (info.Key != ConsoleKey.Enter)
                    {
                        if (info.Key != ConsoleKey.Backspace)
                        {
                            Console.Write("*");
                            Salasana += info.KeyChar;
                        }
                        else if (info.Key == ConsoleKey.Backspace)
                        {
                            if (!string.IsNullOrEmpty(Salasana))
                            {
                                Salasana = Salasana.Substring(0, Salasana.Length - 1);
                                int pos = Console.CursorLeft;
                                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                Console.Write(" ");
                                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                            }
                        }
                        info = Console.ReadKey(true);
                    }
                    Console.WriteLine();
                    if (Salasana == "Password")
                    {
                        
                        while (true)
                        {
                            Console.WriteLine("Hei Admin!");
                            Console.WriteLine("Paina 1 Tarkastellaksesi työntekijöiden tietoja");
                            Console.WriteLine("Paina 2 Muokataksesi työntekijöiden tietoja");
                            Console.WriteLine("Paina 3 Lisätäksesi työntekijän");
                            Console.WriteLine("Paina 0 kirjautuaksesi ulos");
                            string valinta = Console.ReadLine();
                            if (int.TryParse(valinta, out Valinta))
                            {
                                if (Valinta == 1)
                                {

                                }
                                else if (Valinta == 2)
                                {

                                }
                                else if (Valinta == 3)
                                {

                                }
                                else if (Valinta == 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else { Console.WriteLine("Väärä Salasana"); }
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Hei " + Kayttaja + "!");
                        Console.WriteLine("Paina 1 Lisätäksesi tunteja");
                        Console.WriteLine("Paina 2 tarkastella tietojasi");
                        Console.WriteLine("Paina 0 kirjautuaksesi ulos");
                        string valinta = Console.ReadLine();
                        if (int.TryParse(valinta, out Valinta))
                        {
                            if (Valinta == 1)
                            {

                            }
                            else if (Valinta == 2)
                            {

                            }
                            else if (Valinta == 3)
                            {

                            }
                            else if (Valinta == 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
