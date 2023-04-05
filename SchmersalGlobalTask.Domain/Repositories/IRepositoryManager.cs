using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchmersalGlobalTask.Domain.Repositories
{
    public interface IRepositoryManager
    {
        public IMovieRepository MovieRepository { get; }
        public IUnitOfWork UnitOfWork{ get; }
    }
}
