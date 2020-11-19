using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IGolesService
    {
        protected T repo;
        public BaseService(Entities contexto)
        {
            Entities ctx = contexto;
            repo = Activator.CreateInstance(typeof(T), new object[] { contexto }) as T;
        }
s
    }
}
