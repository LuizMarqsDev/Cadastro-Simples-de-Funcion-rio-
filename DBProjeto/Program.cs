using System;
using System.Data.SqlClient;
using BDProjeto;
using BDProjeto.Aplicacao;
using BDProjeto.Dominio;
using BDProjeto.Repositorio;

namespace DOS
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bd = new bd();
            var usuarioAplicacao = UsuarioAplicacaoConstrutor.UsuarioApADO();

            SqlConnection conexao = new SqlConnection(@"data source=LAPTOP-KLHKEUS8\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=ExemploBD");
            conexao.Open();


            Console.Write("Digite o nome do usuário: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o cargo do usuário: ");
            string cargo = Console.ReadLine();
            Console.Write("Digite a data do usuário: ");
            string data = Console.ReadLine();

            var usuarios = new Usuarios
            {
                Nome = nome,
                Cargo = cargo,
                Data = DateTime.Parse(data)

            };


            //usuarios.Id = 5;
            usuarioAplicacao.Salvar(usuarios);

            var dados = usuarioAplicacao.Get();

            foreach (var usuario in dados)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3} ", usuario.Id, usuario.Nome, usuario.Cargo, usuario.Data);
            }
        }
    }
}
