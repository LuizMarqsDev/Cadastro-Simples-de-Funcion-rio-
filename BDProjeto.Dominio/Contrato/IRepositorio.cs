using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.Dominio.Contrato
{
    public interface  IRepositorio<T> where T : class
    {
        void Save(T entidade);
        void Delete(T entidade);
        IEnumerable<T> Get();
        T GetById(string id);
       
    }
}
