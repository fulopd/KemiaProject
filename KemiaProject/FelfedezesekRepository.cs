using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KemiaProject
{
    class FelfedezesekRepository
    {
        private List<Felfedezes> felfedezesekLista;

        public FelfedezesekRepository()
        {
            felfedezesekLista = new List<Felfedezes>();
            Beolvas();
        }

        private void Beolvas()
        {
            using (var sr = new StreamReader("forras/felfedezesek.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(';');
                    felfedezesekLista.Add(new Felfedezes(
                                                sor[0],
                                                sor[1],
                                                sor[2],
                                                Convert.ToInt32(sor[3]),
                                                sor[4]));
                }
            }
        }

        public int Count()
        {
            return felfedezesekLista.Count();
        }

        public int GetOkoriFelfedezesekSzama()
        {
            return felfedezesekLista.Where(x => x.ev.Equals("Ókor")).Count();
        }

        public string VegyjelBekeres()
        {
            Console.Write("5. Feladat: Kérek egy vegyjelet: ");
            string be = Console.ReadLine();
            Regex r = new Regex("^[a-zA-Z]*$");
            while (!r.IsMatch(be) || be.Length > 3)
            {
                Console.Write("5. Feladat: Kérek egy vegyjelet: ");
                be = Console.ReadLine();
            }
            
            return be;

            //be = be.ToLower();
            //if (!string.IsNullOrWhiteSpace(be))
            //{
            //    if (be.Length < 3)
            //    {
            //        string elso = be.Substring(0, 1);

            //        if (elso.ToLower().Equals(elso.ToUpper()))
            //        {
            //            Console.WriteLine("Nem betűt irtál be elso karakternek");
            //            VegyjelBekeres();
            //        }
            //        else
            //        {
            //            Console.WriteLine(be);
            //        }

            //        if (be.Length == 2)
            //        {
            //            string masodik = be.Substring(1, 1);
            //            if (masodik != null)
            //            {
            //                if (masodik.ToLower().Equals(masodik.ToUpper()))
            //                {
            //                    Console.WriteLine("Nem betűt irtál be elso masodik karakternek");
            //                    VegyjelBekeres();
            //                }
            //                else
            //                {
            //                    Console.WriteLine(be);
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("túl hosszu a megadot szöveg");
            //        VegyjelBekeres();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("space!! nono");
            //    VegyjelBekeres();
            //}
        }

        public Felfedezes GetAdatok(string prop)
        {
            prop = prop.ToLower();
            Felfedezes felf = felfedezesekLista.Find(x => x.vegyjel.ToLower().Equals(prop));
            if(felf != null)
            {
                return felf;
            }
            else
            {
                return null;
            }
            
        }

        public int LeghosszabbIdoszak()
        {
            var hos = felfedezesekLista.Where(x => x.evSzamban > 0).OrderByDescending(x => x.evSzamban).ToList();

            int leghosszabb = 0;
            for (int i = 0; i < hos.Count()-1; i++)
            {
                int szam = hos[i].evSzamban - hos[i + 1].evSzamban;
                if (szam > leghosszabb)
                {
                    leghosszabb = szam;
                }
            }

            return leghosszabb;
        }

        public void TobbMintHarom()
        {
            var evek = felfedezesekLista.Where(x => x.evSzamban > 0).GroupBy(x => x.evSzamban).ToList();

            foreach (var item in evek)
            {
                if (item.Count()> 3)
                {
                    Console.WriteLine("\t"+item.Key +": " +item.Count()+" db");
                }
            }
        }
    }
}
