using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuntiLaskin
{
    class Program
    {
       public static string SalasananSuojaus()
        {
            string Salasana = null;
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
            return Salasana;
        }
        static void Main(string[] args)
        {

            String input = File.ReadAllText(@"TyonTekijaLista.txt");
            int rivi = 0, sarake = 0;
            string[,] TyoLista = new string[100, 100];
            foreach (var row in input.Split('\n'))
            {
                sarake = 0;
                foreach (var col in row.Trim().Split('.'))
                {
                    TyoLista[rivi, sarake] = col.Trim();
                    sarake++;
                }
                rivi++;
            }
            /*
            TyoLista[, 0] = Käyttäjänimi
            TyoLista[, 1] = Salasana
            TyoLista[, 2] = Työtunnit
            TyoLista[, 3] = Tuntipalkka(brutto)
            TyoLista[, 4] = Ikä
            TyoLista[, 5] = veroprosentti
            TyoLista[, 6] = Työeläke
            TyoLista[, 7] = Työttömyysvakuutusmaksu
            */
            Console.WriteLine("Hello world");
            string uusiSalasana;
            //Käyttäjän valinta
            while (true)
            {
                //kysytään kuka käyttää
                Console.WriteLine("Anna käyttäjänimi");
                string Kayttaja = Console.ReadLine();
                for (int h = 0; h < TyoLista.GetLength(0); h++)
                {
                    int Valinta; //admin sekä työntekijän valikko valinta muuttuja

                    if (Kayttaja == "Admin")
                    {
                        Salasana = SalasananSuojaus();
                        if (Salasana == TyoLista[3, 1])
                        {
                            Console.WriteLine("Hei Admin!");
                            while (true)
                            {
                                //Admin valikko
                                Console.WriteLine("Paina 1 Tarkastellaksesi työntekijöiden tietoja");
                                Console.WriteLine("Paina 2 Muokataksesi työntekijöiden tietoja");
                                Console.WriteLine("Paina 3 Lisätäksesi työntekijän");
                                Console.WriteLine("Paina 4 muuttaaksesi salasanasi");
                                Console.WriteLine("Paina 0 kirjautuaksesi ulos");
                                //ottaa stringin adminin valinnasta
                                string valinta = Console.ReadLine();
                                //yrittää muuttaa numeroksi
                                if (int.TryParse(valinta, out Valinta))
                                {
                                    if (Valinta == 1)
                                    {
                                        //Tarkastellaan työntekijöiden tietoja
                                        int i;
                                        for (i = 1; i < TyoLista.GetLength(0); i++)
                                        {
                                            if (TyoLista[i, 0] == null)
                                            {
                                                i++;
                                                break;
                                            }
                                        }
                                        for (int s = 0; s < i; s++)
                                        {
                                            Console.WriteLine(TyoLista[s, 0]);
                                        }
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
                                        Console.WriteLine("Syötä salasanasi: ");
                                        string KayttajaSalasana = Console.ReadLine();
                                        int i;
                                        for (i = 0; i < TyoLista.GetLength(0); i++)
                                        {
                                            if (TyoLista[i, 0] == null)
                                            {
                                                break;
                                            }
                                        }
                                        TyoLista[i, 0] = kauttajatunnus;
                                        TyoLista[i, 1] = KayttajaSalasana;
                                        //Console.WriteLine(i + "nimi" + TyoLista[i, 0] + "salasana" + TyoLista[i, 1]);
                                    }
                                    else if (Valinta == 4)
                                    {
                                        Salasana = SalasananSuojaus();
                                        if (Salasana == TyoLista[3, 1])
                                        {
                                            SalasananVaihto SalasanaTyyppi = new SalasananVaihto();
                                            uusiSalasana = SalasanaTyyppi.SalasanaVaihdetaan();

                                            TyoLista[3, 1] = null;
                                            TyoLista[3, 1] = uusiSalasana;
                                            Salasana = TyoLista[3, 1];
                                        }
                                        else
                                        {
                                            Console.WriteLine("Väärä salasana.");
                                            Console.WriteLine();
                                        }
                                       
                                    }
                                    else if (Valinta == 0)
                                    {
                                        Salasana = null;
                                        //paluu käyttäjän valintaan
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Anna luku väliltä 0-4");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Väärä salasana");
                            Salasana = null;
                        }
                        break;
                    }

                    else if (Kayttaja == TyoLista[h, 0])
                    {
                        Salasana = SalasananSuojaus();
                        if (Salasana == TyoLista[h, 1])
                        {
                            Console.WriteLine("Hei " + Kayttaja + "!");
                            while (true)
                            {
                                //työntekijän valikko
                                Console.WriteLine("Paina 1 Lisätäksesi tunteja");
                                Console.WriteLine("Paina 2 tarkastella tietojasi");
                                Console.WriteLine("Paina 3 muuttaaksesi salasanasi");
                                Console.WriteLine("Paina 0 kirjautuaksesi ulos");
                                string valinta = Console.ReadLine();//käyttäjän valinta
                                //Yritetään muuttaa numeroksi
                                if (int.TryParse(valinta, out Valinta))
                                {
                                    if (Valinta == 1)
                                    {
                                        //omien tuntien lisääminen
                                        bool tyotunnitOikein = true;
                                        //Palauttaa luuppiin jos tyotunnitOikein = true
                                        while (tyotunnitOikein == true)
                                        {
                                            Console.Write("Syötä päivän työtuntisi: ");
                                            string tyotunnit = Console.ReadLine();
                                            double tyotunnitDouble;

                                            //yrittää muuntaa doubleksi
                                            if (double.TryParse(tyotunnit, out tyotunnitDouble))
                                            {
                                                Console.Write("Vahvista tuntimäärä " + tyotunnit + " kirjoittamalla se uudestaan: ");
                                                double tyotunnitTarkastus;
                                                //muuntaa syötettävän takistusluvun doubleksi vertailua varten
                                                double.TryParse(Console.ReadLine(), out tyotunnitTarkastus);
                                                //jos tarkistus on väärin, käyttäjä palaa ylemmän tason while-luuppiin ja kirjaa tunnit uudelleen
                                                if (tyotunnitDouble != tyotunnitTarkastus)
                                                {
                                                    Console.WriteLine("Vahvistus on väärin, syötä työtuntisi uudestaan.");
                                                }
                                                else
                                                {
                                                    //Hakee työlistasta työtunnit, muuttaa ne doubleksi
                                                    double tyotunnitSumma = Convert.ToDouble(TyoLista[h, 2]);
                                                    //Laskee haetut työtunnit ja lisätyt työtunnit summaan
                                                    tyotunnitSumma = tyotunnitDouble + tyotunnitSumma;
                                                    //Muuttaa lasketun summan stringiksi, listaan säilyttämistä varten, Tallentaa listaan.
                                                    TyoLista[h, 2] = Convert.ToString(tyotunnitSumma);
                                                    Console.WriteLine("Työtuntiesi asettaminen onnistui!");
                                                    tyotunnitOikein = false;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Syötteeksi hyväksytään vain numerot ja pilkut.");
                                            }
                                        }
                                    }
                                    else if (Valinta == 2)
                                    {
                                        //omien tietojen tarkastelu
                                        var tuntipalkka = TyoLista[h, 3];
                                        var veroprosentti = TyoLista[h, 5];
                                        var tehdytTunnit = TyoLista[h, 2];


                                        //omien tietojen tarkastelu
                                        //pitää etsiä lista ja printtaa se ulos
                                        Console.WriteLine("Käyttäjän tiedot.");
                                        Console.WriteLine("---------------------------");
                                        Console.Write("Käyttäjän nimi: ");
                                        Console.Write(Kayttaja);
                                        Console.WriteLine();
                                        Console.Write("Tuntipalkka: ");
                                        Console.Write(tuntipalkka + "e");
                                        Console.WriteLine();
                                        Console.Write("Veroprosentti: ");
                                        Console.Write(veroprosentti + "%");
                                        Console.WriteLine();
                                        Console.Write("Tehdyt tunnit: ");
                                        Console.WriteLine(tehdytTunnit + "h");
                                        Console.WriteLine("---------------------------");
                                    }
                                    else if (Valinta == 3)
                                    {
                                        Console.WriteLine("Syötä nykyinen salasanasi:");
                                        string AnnettuSalasana = Console.ReadLine();

                                        if (Salasana == AnnettuSalasana)
                                        {
                                            SalasananVaihto SalasanaTyyppi = new SalasananVaihto();
                                            uusiSalasana = SalasanaTyyppi.SalasanaVaihdetaan();

                                            TyoLista[h, 1] = null;
                                            TyoLista[h, 1] = uusiSalasana;
                                            Salasana = TyoLista[h, 1];
                                        }
                                        else
                                        {
                                            Console.WriteLine("Väärä salasana");
                                        }
                                    }
                                    else if (Valinta == 0)
                                    {
                                        //paluu käyttäjän valintaan
                                        Salasana = null;
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
                            Salasana = null;
                        }
                        break;
                    }
                }



            }

        }
    }
}
