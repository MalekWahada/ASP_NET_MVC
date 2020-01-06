using Domain.Entities;
using GestionBibliotheque.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Bibliothequeservice: Service<Bibliotheque> ,IBibliothequeService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public Bibliothequeservice():base(uow)
        {

        }




        public int GetnombreBibliotheque()

        {
            return GetAll().Count();
        }


        // public void AddBib(Bibliotheque bibliotheque)
        //{
        // uow.getRepository<Bibliotheque>().Add(bibliotheque);
        // uow.Commit();
        // }
    }
}
