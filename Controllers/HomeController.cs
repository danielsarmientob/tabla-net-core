using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prueba.Models;


namespace prueba.Controllers
{
    public class HomeController : Controller
    {
        public List<Alumno> listaAlumnos =  new List<Alumno>();
        //  private IAmigoAlmacen amigoAlmacen;
        private IAlumnos alumnoAlmacen;

        //  public HomeController(IAmigoAlmacen AmigoAlmacen){
        //       amigoAlmacen =  AmigoAlmacen;
        //  }
         public HomeController(IAlumnos AlumnoAlmacen){
              alumnoAlmacen =  AlumnoAlmacen;
         }
        // [Route("home/index")]
        // public string Index()
        // {
        //     return amigoAlmacen.dameDatosAmigo(1).Email;
        // }

        // public JsonResult Details(){
        //     Amigo amigo = amigoAlmacen.dameDatosAmigo(1);
        //     return Json(amigo);
        // }

       

        [Route("/")]
        public ViewResult Index()
        {
            
            // Amigo amigo = amigoAlmacen.dameDatosAmigo(1);
            // ViewData["cabecera"] = "Lista Amigo";
            // ViewData["Amigo"]  = amigo;
            // return View(amigo);
            // ViewData["ListaAlumno"]  = this.listaAlumnos;
            //  Console.WriteLine(this.listaAlumnos[0].id_estudiante);
            var modelo = alumnoAlmacen.GetAmigos();
            return View(modelo);
        }

        [Route("home/getAlumnos")]
        public ActionResult GetAlumnos()
        {
            
            var modelo =  alumnoAlmacen.GetAmigos();
            return Json(new { data = modelo});
        }

        // public ViewResult Details()
        // {
        //     Amigo amigo = amigoAlmacen.dameDatosAmigo(1);
        //     ViewData["cabecera"] = "Lista Amigo";
        //     ViewData["Amigo"]  = amigo;
        //     return View(amigo);
        // }


    }
}