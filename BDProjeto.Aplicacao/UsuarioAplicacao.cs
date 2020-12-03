
using BDProjeto.Dominio;
using BDProjeto.Dominio.Contrato;
using BDProjeto.Repositorio;
using BDProjeto.RepositorioADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly IRepositorio<Usuarios> repositorio;
        public UsuarioAplicacao(IRepositorio<Usuarios> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Usuarios usuarios)
        {
            repositorio.Save(usuarios);
        }

        public void Delete(Usuarios usuario)
        {
            repositorio.Delete(usuario);
        }

        public IEnumerable<Usuarios> Get()
        {
            return repositorio.Get();
        }

        public Usuarios GetById(string id)
        {
            return repositorio.GetById(id);
        }

        
    }
}
