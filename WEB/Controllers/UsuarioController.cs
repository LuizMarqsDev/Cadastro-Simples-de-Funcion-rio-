using BDProjeto.Aplicacao;
using BDProjeto.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class UsuarioController : Controller
    {
        /*private UsuarioAplicacao appUsuarios;
        public UsuarioController()
        {
            appUsuarios = UsuarioAplicacaoConstrutor.UsuarioApEF();
        }*/

        // GET: Aluno
        public ActionResult Index()
        {
            var appUsuarios = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var listaUsuario = appUsuarios.Get();
            return View(listaUsuario);
        }

        public ActionResult Cadastrar()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                var appUsuarios = UsuarioAplicacaoConstrutor.UsuarioApADO();
                appUsuarios.Salvar(usuarios);
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        public ActionResult Editar(string id)
        {
            var appUsuarios = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var usuario = appUsuarios.GetById(id);

           if(usuario == null)
           {
                return HttpNotFound();
           }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                var appUsuarios = UsuarioAplicacaoConstrutor.UsuarioApADO();
                appUsuarios.Salvar(usuarios);
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        public ActionResult Detalhes(string id)
        {
            var appUsuarios = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var usuario = appUsuarios.GetById(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        public ActionResult Excluir(string id)
        {
            var appUsuarios = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var usuario = appUsuarios.GetById(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(string id)
        {

            var appUsuarios = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var usuario = appUsuarios.GetById(id);
            appUsuarios.Delete(usuario);
            return RedirectToAction("Index");
        }

    }
}