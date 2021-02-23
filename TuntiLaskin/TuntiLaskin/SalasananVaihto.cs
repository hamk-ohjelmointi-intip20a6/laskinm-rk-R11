using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuntiLaskin
{
    class SalasananVaihto
    {
        //luokan sisäinen muuttuja, julkinen
        public string UusiSalasana { get; set; }

        //konstruktori, jossa voidaan alustaa muuttuja
        public SalasananVaihto()//string salasana)
        {
            //this.UusiSalasana = salasana;
        }

        /*luokan tärkein metodi
         *Kun metodia kutsutaan pääohjelmassa, 
         * syötetään samalla nykyinen salasana.*/
        public string SalasanaVaihdetaan()
        {
            //pyydetää uus salasana ja tallennetaan UusiSalasana muuttujaan
            Console.WriteLine("Anna uusi salasana.");
            string UusiSalasana = Console.ReadLine();

            //Syötetty salasana palautetaan vahvistuksen jälkeen
            Console.WriteLine("Onko tämä oikein?");
            Console.WriteLine(UusiSalasana);
            return UusiSalasana;
        }

    }
}
