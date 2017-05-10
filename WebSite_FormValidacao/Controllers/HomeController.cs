using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidateCreditCard.Models;

namespace ValidateCreditCard.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnvioCartao()
        {
            try
            {
                var nroCartao = Request["txtNro"].Trim();
                string bandeira = "";
                string status = "";
                ValidateCriditCard validacao = new ValidateCriditCard();
                bandeira = validacao.retornarTipoCartao(nroCartao);
                if (validacao.validarNroCartao(nroCartao) == 0)
                {
                    status = "Valido";
                }
                else
                {
                    status = "Invalido";
                }
                string respuesta = bandeira + ": " + nroCartao + " (" + status + ")";
                
                ViewData["Respuesta"] = respuesta;
                return View();
            }
            catch (Exception)
            {
                
                return View();
            }
            
        }

        
    }
}