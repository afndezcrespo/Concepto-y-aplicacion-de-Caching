using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CachingPost.Controllers
{
    public class CachingController : Controller
    {
        // GET: Caching
        public ActionResult Index()
        {
            return View();
        }

        //GET: MostrarImagenes
        [OutputCache( Duration = 5, VaryByParam = "dato")]
        public ActionResult MostrarImagenes(int? dato)
        {
            if (dato == 2)
            {
                var carpetaprincesas = Server.MapPath("../Images/imagenesprincesas"); 
                String[] ficherosprincesas = System.IO.Directory.GetFiles(carpetaprincesas);
                Random rndprincesas = new Random();
                int idimagenprincesas = rndprincesas.Next(0, ficherosprincesas.Length);
                String rutaimagenprincesa = ficherosprincesas[idimagenprincesas];
                int ultimabarraprincesa = rutaimagenprincesa.LastIndexOf(@"\") + 1;
                String imagenprincesa = rutaimagenprincesa.Substring(ultimabarraprincesa);
                ViewBag.ImagenPrincesa = imagenprincesa;
                ViewBag.Dato = 2;
                
            }
            else if (dato == 1)
            {
                var carpetaheroes = Server.MapPath("../Images/imagenesheroes");
                String[] ficherosheroes = System.IO.Directory.GetFiles(carpetaheroes);
                Random rndheroes = new Random();
                int idimagenheroes = rndheroes.Next(0, ficherosheroes.Length);
                String rutaimagenheroe = ficherosheroes[idimagenheroes];
                int ultimabarraheroe = rutaimagenheroe.LastIndexOf(@"\") + 1;
                String imagenheroe = rutaimagenheroe.Substring(ultimabarraheroe);
                ViewBag.ImagenHeroe = imagenheroe;
                ViewBag.Dato = 1;

            }
            else
            {
                ViewBag.Dato = 0;
            }
                          
            return View();
        }
    }
}