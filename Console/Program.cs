
using Domain.Entities;
using Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
      public  static void Main(string[] args)
        {
            Bibliotheque bib1 = new Bibliotheque()
            {
                BibliothequeCode = 1,
                NbrDocument = 9
            };

            IBibliothequeService Bs = new Bibliothequeservice();
            Bs.Add(bib1);
            Bs.Commit();
            Bs.GetnombreBibliotheque();

            Livre lv = new Livre()
            {
                BibliothequeFK = 1,
                NbrDePage = 9
            };

            ILivreService lvs = new LivreService();
            lvs.Add(lv);
            lvs.GetAll();
            lvs.Commit();

           

            //BibContext Ctx = new BibContext();
            //Ctx.Bibliotheques.Add(bib1);
            //Ctx.SaveChanges();
            //System.Console.ReadKey();
            //System.Console.WriteLine("OK");

           

        }
    }
}
