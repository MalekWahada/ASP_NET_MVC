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
  public  class AuteurService : Service<Auteur>, IAuteurService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
    public static IUnitOfWork uow = new UnitOfWork(dbFactory);
    public AuteurService() : base(uow)
    {

    }
}
}
