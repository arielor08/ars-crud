using AfiliateDataAccess.Models;
using AfiliateDataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARS.Controllers
{
    public class AfiliateController : Controller
    {
        // GET: Afiliate
        
        private AfiliadosRepository afiliadosRep = new AfiliadosRepository();
        
        private string connectionStriing = ConfigurationManager.ConnectionStrings["AFILIADOS_EDWIN"].ConnectionString;
        public ActionResult Index()
        {
            ViewBag.Afiliados = afiliadosRep.GetAfiliados(connectionStriing);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Afiliados afiliado)
        {

            afiliadosRep.AddAfiliados(connectionStriing, afiliado);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model= afiliadosRep.GetAfiliadosById(connectionStriing,id);
            return View("Edit",model);
        }

        [HttpPost]
        public ActionResult Edit(Afiliados afiliado)
        {

            afiliadosRep.UpdateAfiliados(connectionStriing, afiliado);
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            var model = afiliadosRep.GetAfiliadosById(connectionStriing, id);
            return View("Delete", model);
        }

        [HttpPost]
        public ActionResult Delete(Afiliados afiliado)
        {

            afiliadosRep.InactivarAfiliado(connectionStriing, afiliado);
            return RedirectToAction("Index");
        }

        public ActionResult EditMonto()
        {
            return View("EditMonto");
        }

        [HttpPost]
        public ActionResult EditMonto(Afiliados afiliado)
        {

            afiliadosRep.UpdateMontoConsumido(connectionStriing, afiliado.Id,afiliado.MontoConsumido);
            return RedirectToAction("Index");
        }

    }
}