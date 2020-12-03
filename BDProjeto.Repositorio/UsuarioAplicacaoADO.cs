
using BDProjeto.Dominio;
using BDProjeto.Dominio.Contrato;
using BDProjeto.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BDProjeto.RepositorioADO
{
    public class UsuarioAplicacaoADO : IRepositorio<Usuarios>
    {
        private bd bd;

        private void Insert(Usuarios usuarios)
        {
            var strQuery = "";
            strQuery += "INSERT INTO usuarios(nome, cargo, data)";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}')", usuarios.Nome, usuarios.Cargo, usuarios.Data);

            using (bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        private void Update(Usuarios usuarios)
        {
            var strQuery = "";
            strQuery += "UPDATE usuarios SET ";
            strQuery += String.Format("nome = '{0}',", usuarios.Nome);
            strQuery += String.Format("cargo = '{0}',", usuarios.Cargo);
            strQuery += String.Format("data = '{0}' ", usuarios.Data);
            strQuery += string.Format("WHERE Id = {0}", usuarios.Id);

            using (bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        public void Save(Usuarios usuarios)
        {
            if (usuarios.Id > 0)
            {
                Update(usuarios);
            }
            else
            {
                Insert(usuarios);
            }
        }

        public void Delete(Usuarios usuario)
        {
            using (bd = new bd())
            {
                var strQuery = string.Format(" DELETE FROM usuarios WHERE Id = {0}", usuario.Id);
                bd.ExecutaComando(strQuery);
            }
        }

        public IEnumerable<Usuarios> Get()
        {
            using (bd = new bd())
            {
                var srtQuery = "SELECT * FROM usuarios";
                var retorno = bd.ExecutaComandoComRetorno(srtQuery);
                return ReaderEmLista(retorno);
            }

        }

        public Usuarios GetById(string id)
        {
            using (bd = new bd())
            {
                var srtQuery = string.Format("SELECT * FROM usuarios WHERE Id = {0}", id);
                var retorno = bd.ExecutaComandoComRetorno(srtQuery);
                return ReaderEmLista(retorno).FirstOrDefault();
            }

        }

        private List<Usuarios> ReaderEmLista(SqlDataReader reader)
        {
            var usuarios = new List<Usuarios>();

            while (reader.Read())
            {
                var tempoObjeto = new Usuarios()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Cargo = reader["cargo"].ToString(),
                    Data = DateTime.Parse(reader["data"].ToString()),
                };

                usuarios.Add(tempoObjeto);

            }

            reader.Close();
            return usuarios;

        }
    }
}
