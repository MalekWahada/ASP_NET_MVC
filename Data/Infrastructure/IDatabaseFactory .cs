
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibliotheque.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        BibContext DataContext { get; }
    }

}
