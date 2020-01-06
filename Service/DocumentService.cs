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
    public class DocumentService : Service<Document>, IDocumentService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public DocumentService() : base(uow)
        {

        }
        public IEnumerable<Document> LISTElivreDispo()
        {
            var v = GetMany(t => t.Etat == Etat.Disponible).OfType<Livre>();
            foreach (var item in v)
            {
                Console.WriteLine("Livre" + item.Titre);
            }
            return v;
        }
    }
}
