using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuntiLaskin
{
    class Program
    {
        static void Main(string[] args)
        {

            String[, ] TyoLista = new string[100, 100];
            //TyoLista[Käyttänimi, Salasana, Työtunnit, Tuntipalkka(brutto), Ikä, Veroprosentti, Työeläke,]
            TyoLista[0, 0] = "pekka";
            TyoLista[0, 1] = "vittu";
            TyoLista[1, 0] = "matti";
            TyoLista[1, 1] = "joo";
            TyoLista[2, 0] = "";

            System.Console.WriteLine(TyoLista[0, 0]);
            System.Console.WriteLine(TyoLista[0, 1]);
            Console.WriteLine("Hello world");
            string Salasana = "";
            //Käyttäjän valinta
            while (true)
            {
                //kysytään kuka käyttää
                Console.WriteLine("Anna käyttäjänimi");
                Console.WriteLine(TyoLista.GetLength(0));
                string Kayttaja = Console.ReadLine();

                int Valinta; //admin sekä työntekijän valikko valinta muuttuja
                if (Kayttaja == "Admin")
                {
                    Console.WriteLine("Anna salasana");

                    ConsoleKeyInfo info = Console.ReadKey(true);
                    //jos ei ole enter
                    while (info.Key != ConsoleKey.Enter)
                    {
                        //jos ei ole backspace
                        if (info.Key != ConsoleKey.Backspace)
                        {
                            //kirjoittaa tähden konsoliin
                            Console.Write("*");
                            //lisää painetun merkin annetun salasanan perään
                            Salasana += info.KeyChar;
                        }
                        //jos on backspace
                        else if (info.Key == ConsoleKey.Backspace)
                        {
                            //onko annettu salasana tyhjä
                            if (!string.IsNullOrEmpty(Salasana))
                            {
                                //poistaa yhden merkin annetun salasanan lopusta
                                Salasana = Salasana.Substring(0, Salasana.Length - 1);
                                //hakee cursorin sijainnin
                                int pos = Console.CursorLeft;
                                //Siirtää cursoria yhden merkin verran vasemmalle
                                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                //vaihtaa tähden tyhjään
                                Console.Write(" ");
                                //siirtää cursorin taas yhden vasemmalle
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
                            //Admin valikko
                            Console.WriteLine("Hei Admin!");
                            Console.WriteLine("Paina 1 Tarkastellaksesi työntekijöiden tietoja");
                            Console.WriteLine("Paina 2 Muokataksesi työntekijöiden tietoja");
                            Console.WriteLine("Paina 3 Lisätäksesi työntekijän");
                            Console.WriteLine("Paina 0 kirjautuaksesi ulos");
                            //ottaa stringin adminin valinnasta
                            string valinta = Console.ReadLine();
                            //yrittää muuttaa numeroksi
                            if (int.TryParse(valinta, out Valinta))
                            {
                                if (Valinta == 1)
                                {
                                    //Tarkastellaan työntekijöiden tietoja
                                }
                                else if (Valinta == 2)
                                {
                                    //Muokataan työntekijöiden tietoja
                                }
                                else if (Valinta == 3)
                                {
                                    //Lisätään työntekijä listaan
                                    Console.Write("Syötä etunimesi: ");
                                    string pieni_etunimi = (Console.ReadLine()).ToLower();
                                    Console.Write("Syötä sukunimesi: ");
                                    string pieni_sukunimi = (Console.ReadLine()).ToLower();
                                    string etunimi = Char.ToUpper(pieni_etunimi[0]) + pieni_etunimi.Substring(1);
                                    string sukunimi = Char.ToUpper(pieni_sukunimi[0]) + pieni_sukunimi.Substring(1);
                                    string kauttajatunnus = sukunimi + etunimi;
                                    Console.WriteLine(kauttajatunnus);
                                    Console.ReadKey();
                                    Console.WriteLine("Syötä salasanasi: ");
                                    string KayttajaSalasana = Console.ReadLine();
                                    int i;
                                    for (i = 0; i < TyoLista.GetLength(0); i++)
                                    {

                                    }
                                    TyoLista[i, 0] = kauttajatunnus;
                                    TyoLista[i, 1] = KayttajaSalasana;
                                    Console.WriteLine(i + "nimi" + TyoLista[i, 0] + "salasana" + TyoLista[i, 1]);
                                }
                                else if (Valinta == 0)
                                {
                                    //paluu käyttäjän valintaan
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Anna luku väliltä 0-3");
                                }
                            }
                        }
                    }
                    else { Console.WriteLine("Väärä Salasana"); }
                }
                for (int h = 0; h < 100; h++)
                {
                    if (Kayttaja == TyoLista[h, 0])
                    {
                        Console.WriteLine("Anna salasana");

                        ConsoleKeyInfo info = Console.ReadKey(true);
                        //jos ei ole enter
                        while (info.Key != ConsoleKey.Enter)
                        {
                            //jos ei ole backspace
                            if (info.Key != ConsoleKey.Backspace)
                            {
                                //kirjoittaa tähden konsoliin
                                Console.Write("*");
                                //lisää painetun merkin annetun salasanan perään
                                Salasana += info.KeyChar;
                            }
                            //jos on backspace
                            else if (info.Key == ConsoleKey.Backspace)
                            {
                                //onko annettu salasana tyhjä
                                if (!string.IsNullOrEmpty(Salasana))
                                {
                                    //poistaa yhden merkin annetun salasanan lopusta
                                    Salasana = Salasana.Substring(0, Salasana.Length - 1);
                                    //hakee cursorin sijainnin
                                    int pos = Console.CursorLeft;
                                    //Siirtää cursoria yhden merkin verran vasemmalle
                                    Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                    //vaihtaa tähden tyhjään
                                    Console.Write(" ");
                                    //siirtää cursorin taas yhden vasemmalle
                                    Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                }
                            }
                            info = Console.ReadKey(true);
                        }
                        Console.WriteLine();
                        if (Salasana == TyoLista[h, 1])
                        {
                            while (true)
                            {
                                //työntekijän valikko
                                Console.WriteLine("Hei " + Kayttaja + "!");
                                Console.WriteLine("Paina 1 Lisätäksesi tunteja");
                                Console.WriteLine("Paina 2 tarkastella tietojasi");
                                Console.WriteLine("Paina 0 kirjautuaksesi ulos");
                                string valinta = Console.ReadLine();//käyttäjän valinta
                                //Yritetään muuttaa numeroksi
                                if (int.TryParse(valinta, out Valinta))
                                {
                                    if (Valinta == 1)
                                    {
                                        //omien tuntien lisääminen
                                    }
                                    else if (Valinta == 2)
                                    {
                                        //omien tietojen tarkastelu
                                    }
                                    else if (Valinta == 0)
                                    {
                                        //paluu käyttäjän valintaan
                                        break;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Anna luku väliltä 0 - 2");
                                }
                            }
                        }
                        else 
                        { 
                            Console.WriteLine("Väärä salasana"); 
                        }
                        break;
                    }
                    else 
                    { 
                        //Console.WriteLine("käyttäjää ei löydy"); 
                    }
                }
            }
        }
    }
}
