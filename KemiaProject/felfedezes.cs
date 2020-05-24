using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemiaProject
{
    class Felfedezes
    {
        //Év;Elem;Vegyjel;Rendszám;Felfedező
        //Ókor; Szén;C;6;Ismeretlen
        //1250;Arzén;As;33;Albertus Magnus

        public string ev { get; set; }
        public string elem { get; set; }
        public string vegyjel { get; set; }
        public int rendszam { get; set; }
        public string felfedezo { get; set; }
        public int evSzamban { get; set; }
        public Felfedezes(string ev, string elem, string vegyjel, int rendszam, string felfedezo)
        {
            this.ev = ev;
            this.elem = elem;
            this.vegyjel = vegyjel;
            this.rendszam = rendszam;
            this.felfedezo = felfedezo;

            int evSzamban = 0;
            int.TryParse(ev, out evSzamban);
            this.evSzamban = evSzamban;
        }

    }
}
