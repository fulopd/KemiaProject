using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemiaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. feladat
            FelfedezesekRepository repo = new FelfedezesekRepository();

            //3. feladat
            Console.WriteLine("3. feladat: Elemek száma: " + repo.Count());

            //4. feladat
            Console.WriteLine("4. feladat: Felfedezések száma az ókorban: {0}", repo.GetOkoriFelfedezesekSzama());

            // 5. feladat
            string be = repo.VegyjelBekeres();
            while (be == null)
            {
                be = repo.VegyjelBekeres();

            }
            
            
            //6. feladat
            Console.WriteLine("6. feladat: Keresés");

            var felf = repo.GetAdatok(be);
            if (felf != null)
            {
                Console.WriteLine("\tAz elem vegyjele: " + felf.vegyjel);
                Console.WriteLine("\tAz elem neve: " + felf.elem);
                Console.WriteLine("\tRendszáma: " + felf.rendszam);
                Console.WriteLine("\tFelfedezés éve: " + felf.ev);
                Console.WriteLine("\tFelfedező: " + felf.felfedezo);
            }
            else
            {
                Console.WriteLine("Nincs ilyen elem az adatbázisban!");
            }


            //7. feladat
            Console.WriteLine("7. feladat: " + repo.LeghosszabbIdoszak());

            //8. feladat
            Console.WriteLine("8. feladat: ");
            repo.TobbMintHarom();

            Console.ReadKey();
        }
    }
}
