using System;
using System.Collections.Generic;
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
            while(true)
            {
                //pyydetää uus salasana ja tallennetaan UusiSalasana muuttujaan
                Console.WriteLine("Anna uusi salasana.");
                string UusiSalasana = Console.ReadLine();

                Console.WriteLine("Anna uusi salasana uudelleen.");
                string UusiSalasanaToistamiseen = Console.ReadLine();

                if(UusiSalasana == UusiSalasanaToistamiseen)
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
}
