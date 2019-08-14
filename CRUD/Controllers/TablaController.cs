using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.Models.ViewModels;
namespace CRUD.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListaTablaViewModel> lst;
            using (masterEntities1 db = new masterEntities1())
            {
                
                 lst = (from d in db.Tabla
                           select new ListaTablaViewModel
                           {
                               Id = d.id,
                               Nombre = d.nombre,
                               Correo = d.correo,
                               Fecha = d.fecha
                           }).ToList();

}
                return View(lst);
        }

        public ActionResult Nuevo ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (masterEntities1 db =new masterEntities1())
                    {
                        var otabla = new Tabla();
                        otabla.id = model.Id;
                        otabla.correo = model.Correo;
                        otabla.fecha = model.Fecha;
                        otabla.nombre = model.Nombre;
                       
                        db.Tabla.Add(otabla);
                        db.SaveChanges();

                    }
                    return Redirect("/");
                }
                return View(model);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
}