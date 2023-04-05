using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchmersalGlobalTask.Services.Abstraction
{
    public interface IServiceManager
    {
        public IMovieService MovieSrvc { get; }  
    }
}
