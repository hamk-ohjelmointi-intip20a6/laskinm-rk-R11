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
            Console.ForegroundColor = ConsoleColor.Green;
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
            TyoLista[, 6] = Työttömyysvakuutusmaksu
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

                    if (Kayttaja == TyoLista[0, 0])
                    {
                        string Salasana = SalasananSuojaus();
                        if (Salasana == TyoLista[0, 1])
                        {
                            Console.WriteLine("Hei " + Kayttaja + "!");
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
                                        while(true)
                                        {
                                            Console.WriteLine("Työntekijät:");
                                            int i;
                                            for (i = 1; i < TyoLista.GetLength(0); i++)
                                            {
                                                if (TyoLista[i, 0] == null)
                                                {
                                                    i++;
                                                    break;
                                                }
                                            }
                                            for (int s = 1; s < i; s++)
                                            {
                                                Console.WriteLine(TyoLista[s, 0]);
                                            }
                                            for (i = 1; i < TyoLista.GetLength(0); i++)
                                            {
                                                Console.WriteLine("Kenen tietoja tahdot katsella?");
                                                Console.WriteLine("Paina 0 poistuaksesi");
                                                string TyontekijanTarkastus = Console.ReadLine();
                                                if (TyontekijanTarkastus == TyoLista[i, 0])
                                                {
                                                    var tuntipalkka = TyoLista[i, 3];
                                                    var veroprosentti = TyoLista[i, 5];
                                                    var tehdytTunnit = TyoLista[i, 2];
                                                    Console.WriteLine("Tässä on tiedot.");
                                                    Console.WriteLine("---------------------------");
                                                    Console.Write("Käyttäjän nimi: ");
                                                    Console.Write(TyoLista[i, 0]);
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
                                                    while (true)
                                                    {
                                                        Console.WriteLine("Paina 1 muokataksesi käyttäjänimeä");
                                                        Console.WriteLine("Paina 2 muokataksesi tehtyjä työtunteja");
                                                        Console.WriteLine("Paina 3 muokataksesi brutto palkkaa");
                                                        Console.WriteLine("Paina 4 muokataksesi veroprosenttia");
                                                        Console.WriteLine("Paina 0 palataksesi");

                                                        string tyonTekijanMuokkaus = Console.ReadLine();
                                                        if (int.TryParse(tyonTekijanMuokkaus, out int TyonTekijanMuokkaus))
                                                        {
                                                            if (TyonTekijanMuokkaus == 1)
                                                            {
                                                                Console.WriteLine("Anna Uusi käyttäjänimi");
                                                                string UusiKayttajaNimi = Console.ReadLine();
                                                                TyoLista[i, 0] = UusiKayttajaNimi;
                                                            }
                                                            else if (TyonTekijanMuokkaus == 2)
                                                            {
                                                                Console.WriteLine("Anna kaikki tehdyt tunnit yhteensä");
                                                                string UusiTehdytTunnit = Console.ReadLine();
                                                                TyoLista[i, 2] = UusiTehdytTunnit;
                                                            }
                                                            else if (TyonTekijanMuokkaus == 3)
                                                            {
                                                                Console.WriteLine("Anna uusi brutto palkka");
                                                                string UusiBrutto = Console.ReadLine();
                                                                TyoLista[i, 3] = UusiBrutto;
                                                            }
                                                            else if (TyonTekijanMuokkaus == 4)
                                                            {
                                                                Console.WriteLine("Anna uusi veroprosentti");
                                                                string UusiVeroProsentti = Console.ReadLine();
                                                                TyoLista[i, 5] = UusiVeroProsentti;
                                                            }
                                                            else if (TyonTekijanMuokkaus == 0)
                                                            {
                                                                break;
                                                            }
                                                            else { Console.WriteLine("Anna luku väliltä 0-4"); }
                                                        }
                                                    }
                                                }
                                            }
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
                                        //Lisää työntekijän syntymäaika
                                        Console.Write("Syötä syntymäaikasi (PP.KK.VVVV): ");
                                        string[] syntymaAika = (Console.ReadLine()).Split('.');
                                        if (syntymaAika[1].Length == 1)
                                        {
                                            syntymaAika[1] = "0" + syntymaAika[1];
                                        }
                                        if (syntymaAika[0].Length == 1)
                                        {
                                            syntymaAika[0] = "0" + syntymaAika[0];
                                        }
                                        TyoLista[h, 4] = syntymaAika[2] + "-" + syntymaAika[1] + "-" + syntymaAika[0];
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
                                                                                int f;
                                        for (f = 0; f < TyoLista.GetLength(0); f++)
                                        {
                                            if (TyoLista[f, 0] == null)
                                            {
                                                f--;
                                                break;
                                            }
                                        }
                                        int q;
                                        for (q = 0; q < TyoLista.GetLength(1); q++)
                                        {
                                            if (TyoLista[1, q] == null)
                                            {
                                                break;
                                            }
                                        }
                                        int s = q - 1;
                                        using (var sw = new StreamWriter(@"TyonTekijaLista.txt"))
                                        {
                                            for (int p = 0; p < f; p++)
                                            {
                                                for (int k = 0; k < q; k++)
                                                {
                                                    sw.Write(TyoLista[p, k]);
                                                    if (k < s)
                                                    {
                                                        sw.Write(".");
                                                    }
                                                }
                                                sw.Write("\n");
                                            }
                                            sw.Flush();
                                            sw.Close();
                                        }
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
                        string Salasana = SalasananSuojaus();
                        if (Salasana == TyoLista[h, 1])
                        {
                            //LASKUT
                            double kauttajaTyoTunnit = Convert.ToDouble(TyoLista[h, 2]);
                            double kauttajaTuntiPalkka = Convert.ToDouble(TyoLista[h, 3]);
                            double kauttajaVeroProsentti = (Convert.ToDouble(TyoLista[h, 5]) / 100);
                            string syntymaPaivaString = TyoLista[h, 4];
                            DateTime syntymaPaiva = Convert.ToDateTime(TyoLista[h, 4]); //YYYY-MM-DD

                            DateTime paivaNyt = DateTime.Now; //YYYY-MM-DD
                            string paivaNytString = paivaNyt.ToString("yyyy-MM-dd").Remove(4, 1);
                            paivaNytString = paivaNytString.Remove(6, 1);
                            int paivaNytInt = Convert.ToInt32(paivaNytString);
                            Console.WriteLine(paivaNytString);

                            syntymaPaivaString = syntymaPaivaString.Remove(4, 1);
                            syntymaPaivaString = syntymaPaivaString.Remove(6, 1);
                            Console.WriteLine(syntymaPaivaString);
                            int syntymapaivaInt = Convert.ToInt32(syntymaPaivaString);
                            var kauttajaIkaString = Convert.ToString(paivaNytInt - syntymapaivaInt).Remove(2);
                            int kauttajaIka = Convert.ToInt16(kauttajaIkaString);
                            Console.WriteLine(kauttajaIka);

                            double kauttajaTyoElakeProsentti = 0;

                            if (kauttajaIka < 53)
                            {
                                kauttajaTyoElakeProsentti = 0.015;
                            }
                            else if (kauttajaIka >= 53 && kauttajaIka < 63)
                            {
                                kauttajaTyoElakeProsentti = 0.017;
                            }

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
                                                                                int f;
                                        for (f = 0; f < TyoLista.GetLength(0); f++)
                                        {
                                            if (TyoLista[f, 0] == null)
                                            {
                                                f--;
                                                break;
                                            }
                                        }
                                        int q;
                                        for (q = 0; q < TyoLista.GetLength(1); q++)
                                        {
                                            if (TyoLista[1, q] == null)
                                            {
                                                break;
                                            }
                                        }
                                        int s = q - 1;
                                        using (var sw = new StreamWriter(@"TyonTekijaLista.txt"))
                                        {
                                            for (int p = 0; p < f; p++)
                                            {
                                                for (int k = 0; k < q; k++)
                                                {
                                                    sw.Write(TyoLista[p, k]);
                                                    if (k < s)
                                                    {
                                                        sw.Write(".");
                                                    }
                                                }
                                                sw.Write("\n");
                                            }
                                            sw.Flush();
                                            sw.Close();
                                        }
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
