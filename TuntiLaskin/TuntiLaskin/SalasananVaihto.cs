using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuntiLaskin
{
    class SalasananVaihto
    {
        public string Salasana { get; set; }

        public SalasananVaihto(string salasana)
        {
            this.Salasana = salasana;
        }

        public void SalasanaVaihdetaan(string SyotettySalasana)
        {
            Salasana = Console.ReadLine();
            //SyotettySalasana 
        }

    }
}
