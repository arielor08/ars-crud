using AfiliateDataAccess;
using AfiliateDataAccess.Models;
using AfiliateDataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PruebaARS.Controllers
{
    public class AfiliateController : Controller
    {
        private AfiliadosRepository afiliadosRep = new AfiliadosRepository();


        private string connectionStriing = ConfigurationManager.ConnectionStrings["AFILIADOS_EDWIN"].ConnectionString;
        public IEnumerable<Afiliados> Index()
        {
            return afiliadosRep.GetAfiliados(connectionStriing);
        }

        public Afiliados Create(Afiliados afiliado)
        {
            return afiliadosRep.AddAfiliados(connectionStriing, afiliado);
        }

        
    }
}
