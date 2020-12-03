using BDProjeto.Dominio;
using BDProjeto.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.RepositorioEF
{
    public class UsuarioRepositorioEF : IRepositorio<Usuarios>
    {
        private readonly BD bd;

        public UsuarioRepositorioEF()
        {
            bd = new BD();
        }
        public void Delete(Usuarios entidade)
        {
            var usuarioDelete = bd.usuario.First(x => x.Id == entidade.Id);
            bd.Set<Usuarios>().Remove(usuarioDelete);
            bd.SaveChanges();
        }

        public IEnumerable<Usuarios> Get()
        {
            return bd.usuario;
        }

        public Usuarios GetById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);

            return bd.usuario.First(x => x.Id == idInt);
        }

        public void Save(Usuarios entidade)
        {
            if(entidade.Id > 0)
            {
                var usuarioAlterar = bd.usuario.First(x => x.Id == entidade.Id);
                usuarioAlterar.Nome = entidade.Nome;
                usuarioAlterar.Cargo = entidade.Cargo;
                usuarioAlterar.Data = entidade.Data;
            }
            else
            {
                bd.usuario.Add(entidade);
            }

            bd.SaveChanges();
        }
    }
}
