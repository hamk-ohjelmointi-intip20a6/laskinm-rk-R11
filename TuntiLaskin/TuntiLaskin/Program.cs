using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuntiLaskin
{
    class SalasananVaihto
    {
        //konstruktori
        public SalasananVaihto()
        {
        }

        /*luokan tärkein metodi. Kun metodia kutsutaan pääohjelmassa,  syötetään samalla nykyinen salasana.*/
        public string SalasanaVaihdetaan()
        {
            while (true)
            {
                //pyydetää uus salasana ja tallennetaan UusiSalasana muuttujaan
                Console.WriteLine("Anna uusi salasana.");
                string UusiSalasana = Console.ReadLine();
                Console.WriteLine("Anna uusi salasana uudelleen.");
                string UusiSalasanaToistamiseen = Console.ReadLine();
                if (UusiSalasana == UusiSalasanaToistamiseen)
                {
                    //Syötetty salasana palautetaan vahvistuksen jälkeen
                    Console.WriteLine("Salasana on muutettu");
                    Console.WriteLine();
                    return UusiSalasana;
                }
                else
                {
                    Console.WriteLine("Syötä salasana uudelleen.");
                    Console.WriteLine("--------------------------");
                }
            }
        }
    }
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
            DateTime AikaNyt = DateTime.Now;
            int luku = Convert.ToInt16(TyoLista[0, 2]);
            if (luku < AikaNyt.Month)
            {
                int i;
                for (i = 1; i < TyoLista.GetLength(0); i++)
                {
                    if (TyoLista[i, 2] == null)
                    {
                        i++;
                        break;
                    }
                }
                for (int s = 1; s < i; s++)
                {
                    TyoLista[s, 2] = "0";
                }
                string UusiKuukausi = AikaNyt.Month.ToString();
                TyoLista[0, 2] = UusiKuukausi;
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

            Console.WriteLine("Tervetuloa tuntilaskuriin!");
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
                                Console.WriteLine("Paina 1 Tarkastellaksesi sekä muokataksesi työntekijöiden tietoja");
                                Console.WriteLine("Paina 2 Lisätäksesi työntekijän");
                                Console.WriteLine("Paina 3 Vaihtaaksesi salasanasi");
                                Console.WriteLine("Paina 0 kirjautuaksesi ulos ja tallentaaksesi tiedot");
                                //ottaa stringin adminin valinnasta
                                string valinta = Console.ReadLine();
                                //yrittää muuttaa numeroksi
                                if (int.TryParse(valinta, out Valinta))
                                {
                                    if (Valinta == 1)
                                    {
                                        while(true)
                                        {
                                            int i;
                                            for (i = 1; i < TyoLista.GetLength(0); i++)
                                            {
                                                //Tarkastellaan työntekijöiden tietoja
                                                Console.Clear();
                                                Console.WriteLine("Palkkakauden vaihde: " + DateTime.DaysInMonth(AikaNyt.Year, AikaNyt.Month) + "." + AikaNyt.Month + "." + AikaNyt.Year);
                                                Console.WriteLine("Työntekijät:");
                                                int m;
                                                for (m = 1; m < TyoLista.GetLength(0); m++)
                                                {
                                                    if (TyoLista[m, 0] == null)
                                                    {
                                                        m++;
                                                        break;
                                                    }
                                                }
                                                for (int s = 1; s < m; s++)
                                                {
                                                    Console.WriteLine(TyoLista[s, 0]);
                                                }
                                                Console.WriteLine("Tietoja tarkastellaksesi, syötä valitun henkilön käyttäjätunnus");
                                                Console.WriteLine("Paina 0 poistuaksesi\n");
                                                string TyontekijanTarkastus = Console.ReadLine();
                                                if (TyontekijanTarkastus == TyoLista[i, 0])
                                                {
                                                    var tuntipalkka = TyoLista[i, 3];
                                                    var veroprosentti = TyoLista[i, 5];
                                                    var tehdytTunnit = TyoLista[i, 2];
                                                    var ika = TyoLista[i, 4];
                                                    //var bruttopalkka = TyoLista[i, 6];   ??
                                                    Console.Clear();
                                                    //LASKUT
                                                    double kauttajaTyoTunnit = Convert.ToDouble(TyoLista[i, 2]);
                                                    double kauttajaTuntiPalkka = Convert.ToDouble(TyoLista[i, 3]);
                                                    double kauttajaVeroProsentti = (Convert.ToDouble(TyoLista[i, 5]) / 100);
                                                    string syntymaPaivaString = TyoLista[i, 4];
                                                    DateTime syntymaPaiva = Convert.ToDateTime(TyoLista[i, 4]); //YYYY-MM-DD

                                                    DateTime paivaNyt = DateTime.Now; //YYYY-MM-DD
                                                    string paivaNytString = paivaNyt.ToString("yyyy-MM-dd").Remove(4, 1);
                                                    paivaNytString = paivaNytString.Remove(6, 1);
                                                    int paivaNytInt = Convert.ToInt32(paivaNytString);

                                                    syntymaPaivaString = syntymaPaivaString.Remove(4, 1);
                                                    syntymaPaivaString = syntymaPaivaString.Remove(6, 1);
                                                    int syntymapaivaInt = Convert.ToInt32(syntymaPaivaString);
                                                    var kauttajaIkaString = Convert.ToString(paivaNytInt - syntymapaivaInt).Remove(2);
                                                    int kauttajaIka = Convert.ToInt16(kauttajaIkaString);

                                                    double kauttajaTyoElakeProsentti = 0;

                                                    if (kauttajaIka < 53)
                                                    {
                                                        kauttajaTyoElakeProsentti = 0.015;
                                                    }
                                                    else if (kauttajaIka >= 53 && kauttajaIka < 63)
                                                    {
                                                        kauttajaTyoElakeProsentti = 0.017;
                                                    }
                                                    Console.WriteLine("\n---------------------------");
                                                    Console.Write("Nimi: ");
                                                    Console.Write(TyoLista[i, 0]);
                                                    Console.WriteLine();
                                                    Console.Write("Syntymäaika: ");
                                                    Console.Write(TyoLista[i, 4]);
                                                    Console.WriteLine();
                                                    Console.Write("Tuntipalkka: ");
                                                    Console.Write(tuntipalkka + "e");
                                                    Console.WriteLine();
                                                    Console.Write("Veroprosentti: ");
                                                    Console.Write(veroprosentti + "%");
                                                    Console.WriteLine();
                                                    Console.Write("Työeläkekerroin: " + kauttajaTyoElakeProsentti);
                                                    Console.WriteLine();
                                                    Console.Write("Tehdyt tunnit: ");
                                                    Console.WriteLine(tehdytTunnit + "h");
                                                    Console.WriteLine("---------------------------");
                                                    //Console.Write("Bruttopalkka: ");
                                                    //Console.WriteLine(bruttopalkka + "e");
                                                    while (true)
                                                    {
                                                        Console.WriteLine("Paina 1 muokataksesi käyttäjänimeä");
                                                        Console.WriteLine("Paina 2 muokataksesi tehtyjä työtunteja");
                                                        Console.WriteLine("Paina 3 muokataksesi bruttopalkkaa");
                                                        Console.WriteLine("Paina 4 muokataksesi veroprosenttia");
                                                        Console.WriteLine("Paina 5 muokataksesi salasanaa");
                                                        Console.WriteLine("Paina 6 poistaaksesi käyttäjän");
                                                        Console.WriteLine("Paina 0 palataksesi\n");
                                                        string tyonTekijanMuokkaus = Console.ReadLine();
                                                        if (int.TryParse(tyonTekijanMuokkaus, out int TyonTekijanMuokkaus))
                                                        {
                                                            if (TyonTekijanMuokkaus == 1)
                                                            {
                                                                Console.WriteLine("Anna Uusi käyttäjänimi");
                                                                string UusiKayttajaNimi = Console.ReadLine();
                                                                TyoLista[i, 0] = UusiKayttajaNimi;
                                                                Console.Clear();
                                                            }
                                                            else if (TyonTekijanMuokkaus == 2)
                                                            {
                                                                Console.WriteLine("Anna kaikki tehdyt tunnit yhteensä");
                                                                string UusiTehdytTunnit = Console.ReadLine();
                                                                TyoLista[i, 2] = UusiTehdytTunnit;
                                                                Console.Clear();
                                                            }
                                                            else if (TyonTekijanMuokkaus == 3)
                                                            {
                                                                Console.WriteLine("Anna uusi bruttopalkka");
                                                                string UusiBrutto = Console.ReadLine();
                                                                TyoLista[i, 3] = UusiBrutto;
                                                                Console.Clear();
                                                            }
                                                            else if (TyonTekijanMuokkaus == 4)
                                                            {
                                                                Console.WriteLine("Anna uusi veroprosentti");
                                                                string UusiVeroProsentti = Console.ReadLine();
                                                                TyoLista[i, 5] = UusiVeroProsentti;
                                                                Console.Clear();
                                                            }
                                                            else if (TyonTekijanMuokkaus == 5)
                                                            {
                                                                Console.WriteLine("Anna uusi salasana");
                                                                string Uusisalasana = Console.ReadLine();
                                                                TyoLista[i, 1] = Uusisalasana;
                                                                Console.Clear();
                                                            }
                                                            else if (TyonTekijanMuokkaus == 6)
                                                            {
                                                                Console.WriteLine("Oletko varma?\nTätä muutosta ei voi perua tämän jälkeen\nKirjoita \"Kyllä\" poitaaksesi");
                                                                string PoistoValintaKylla = Console.ReadLine();
                                                                if (PoistoValintaKylla == "Kyllä" || PoistoValintaKylla == "kyllä")
                                                                {
                                                                    for (int s = 0; s < 7; s++)
                                                                    {
                                                                        TyoLista[i, s] = null;
                                                                    }
                                                                }
                                                            }
                                                            else if (TyonTekijanMuokkaus == 0)
                                                            {
                                                                Console.Clear();
                                                                break;
                                                            }
                                                            else { Console.WriteLine("Anna luku väliltä 0-4"); }
                                                        }
                                                    }
                                                }
                                                else if (TyontekijanTarkastus == "0") { break; }
                                                else
                                                    Console.WriteLine("Käyttäjää ei löydy");
                                            }
                                            break;
                                        }
                                    }
                                    else if (Valinta == 2)
                                    {
                                        //Lisätään työntekijä listaan
                                        Console.Write("Syötä uuden työntekijän etunimi: ");
                                        string pieni_etunimi = (Console.ReadLine()).ToLower();
                                        Console.Write("Syötä uuden työntekijän sukunimi: ");
                                        string pieni_sukunimi = (Console.ReadLine()).ToLower();
                                        string etunimi = Char.ToUpper(pieni_etunimi[0]) + pieni_etunimi.Substring(1);
                                        string sukunimi = Char.ToUpper(pieni_sukunimi[0]) + pieni_sukunimi.Substring(1);
                                        string kauttajatunnus = sukunimi + etunimi;
                                        Console.WriteLine("Uusi käyttäjänimi: " + kauttajatunnus);
                                        Console.WriteLine("Syötä salasanasi: ");
                                        string KayttajaSalasana = Console.ReadLine();
                                        //Lisää työntekijän syntymäaika
                                        Console.Write("Syötä uuden työntekijän syntymäaika (PP.KK.VVVV): ");
                                        string[] syntymaAika = (Console.ReadLine()).Split('.');
                                        if (syntymaAika[1].Length == 1)
                                        {
                                            syntymaAika[1] = "0" + syntymaAika[1];
                                        }
                                        if (syntymaAika[0].Length == 1)
                                        {
                                            syntymaAika[0] = "0" + syntymaAika[0];
                                        }
                                        Console.Write("Anna uuden työntekijän bruttopalkka tunnilta: ");
                                        string UudenTyöntekijänBrutto = Console.ReadLine();
                                        Console.Write("Anna uuden työntekijän veroprosentti: ");
                                        string UudenyöntekijänVeroProsentti = Console.ReadLine();
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
                                        TyoLista[i, 2] = "0";
                                        TyoLista[i, 3] = UudenTyöntekijänBrutto;
                                        TyoLista[i, 4] = syntymaAika[2] + "-" + syntymaAika[1] + "-" + syntymaAika[0];
                                        TyoLista[i, 5] = UudenyöntekijänVeroProsentti;
                                        Console.Write("Uusi työntekijä on luotu käyttäjänimellä: " + TyoLista[i, 0]);
                                        Console.WriteLine("\nPaina enter jatkaaksesi");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else if(Valinta == 3)
                                    {
                                        Salasana = SalasananSuojaus();
                                        if (Salasana == TyoLista[0, 1])
                                        {
                                            string uusiSalasana;
                                            SalasananVaihto SalasanaTyyppi = new SalasananVaihto();
                                            uusiSalasana = SalasanaTyyppi.SalasanaVaihdetaan();

                                            TyoLista[0, 1] = null;
                                            TyoLista[0, 1] = uusiSalasana;
                                            Salasana = TyoLista[0, 1];
                                        }
                                        else
                                        {
                                            Console.WriteLine("Väärä salasana.");
                                            Console.WriteLine();
                                        }
                                    }
                                    else if (Valinta == 0)
                                    {
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
                                        int p;
                                        int s = q - 1;
                                        using (var sw = new StreamWriter(@"TyonTekijaLista.txt"))
                                        {
                                            for (p = 0; p < f; p++)
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
                                        Salasana = null;
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Anna luku väliltä 0-2");
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

                            syntymaPaivaString = syntymaPaivaString.Remove(4, 1);
                            syntymaPaivaString = syntymaPaivaString.Remove(6, 1);
                            int syntymapaivaInt = Convert.ToInt32(syntymaPaivaString);
                            var kauttajaIkaString = Convert.ToString(paivaNytInt - syntymapaivaInt).Remove(2);
                            int kauttajaIka = Convert.ToInt16(kauttajaIkaString);

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
                                Console.WriteLine("Paina 2 tarkastellaksesi tietojasi");
                                Console.WriteLine("Paina 3 vaihtaaksesi salasanasi");
                                Console.WriteLine("Paina 0 kirjautuaksesi ulos ja tallentaaksesi tiedot");
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
                                            Console.WriteLine("Syötä päivän työtuntisi\nSyöttämällä 0, palaat päävalikkoon");
                                            string tyotunnit = Console.ReadLine();
                                            if (tyotunnit == "0")
                                            {
                                                tyotunnitOikein = false;
                                                break;
                                            }
                                            double tyotunnitDouble;

                                            //yrittää muuntaa doubleksi
                                            if (double.TryParse(tyotunnit, out tyotunnitDouble))
                                            {
                                                Console.WriteLine("Vahvista tuntimäärä " + tyotunnit + " kirjoittamalla se uudestaan\nSyöttämällä \"0\", palaat päävalikkoon");
                                                double tyotunnitTarkastus;
                                                //muuntaa syötettävän takistusluvun doubleksi vertailua varten
                                                double.TryParse(Console.ReadLine(), out tyotunnitTarkastus);
                                                if (tyotunnitTarkastus == 0)
                                                {
                                                    tyotunnitOikein = false;
                                                    break;
                                                }
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
                                                    Console.WriteLine("Työtuntiesi asettaminen onnistui!\nPaina Enter jatkaaksesi");
                                                    Console.ReadKey();
                                                    tyotunnitOikein = false;
                                                }
                                                Console.Clear();
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
                                        var ika = TyoLista[h, 4];
                                        //var bruttopalkka = TyoLista[i, 6];   ??
                                        Console.WriteLine("---------------------------");
                                        Console.Write("Käyttäjän nimi: ");
                                        Console.Write(TyoLista[h, 0]);
                                        Console.WriteLine();
                                        Console.Write("Syntymäaikasi: ");
                                        Console.Write(TyoLista[h, 4]);
                                        Console.WriteLine();
                                        Console.Write("Tuntipalkka: ");
                                        Console.Write(tuntipalkka + "e");
                                        Console.WriteLine();
                                        Console.Write("Veroprosentti: ");
                                        Console.Write(veroprosentti + "%");
                                        Console.WriteLine();
                                        Console.Write("Työeläkekerroin: " + kauttajaTyoElakeProsentti);
                                        Console.WriteLine();
                                        Console.Write("Tehdyt tunnit: ");
                                        Console.WriteLine(tehdytTunnit + "h");
                                        Console.WriteLine("Seuraava palkkapäivä: " + DateTime.DaysInMonth(AikaNyt.Year, AikaNyt.Month) + "." + AikaNyt.Month + "." + AikaNyt.Year);
                                        Console.WriteLine("---------------------------");
                                        //Console.Write("Bruttopalkka: ");
                                        //Console.WriteLine(bruttopalkka + "e");
                                    }
                                    else if (Valinta == 3)
                                    {
                                        Console.WriteLine("Syötä nykyinen salasanasi:");
                                        string AnnettuSalasana = Console.ReadLine();

                                        if (Salasana == AnnettuSalasana)
                                        {
                                            string uusiSalasana;
                                            SalasananVaihto SalasanaTyyppi = new SalasananVaihto();
                                            uusiSalasana = SalasanaTyyppi.SalasanaVaihdetaan();

                                            TyoLista[h, 1] = null;
                                            TyoLista[h, 1] = uusiSalasana;
                                            Salasana = TyoLista[h, 1];
                                            Console.Clear();

                                        }
                                        else
                                        {
                                            Console.WriteLine("Väärä salasana");
                                        }
                                    }
                                    else if (Valinta == 0)
                                    {
                                        //paluu käyttäjän valintaan
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
                                        Salasana = null;
                                        Console.Clear();
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
