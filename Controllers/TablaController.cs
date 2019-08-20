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
        masterEntities1 dbcontext = new masterEntities1();
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
           // var caca = dbcontext.Tabla.ToList();
           // ViewBag.caca = caca;
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
                    return Redirect("/Tabla");
                }
                return View(model);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public ActionResult Editar(int id)
        {
            TablaViewModel model = new TablaViewModel(); 
            using (masterEntities1 db= new masterEntities1 ()) {
                var oTabla = db.Tabla.Find(id);
                model.Nombre = oTabla.nombre;
                model.Correo = oTabla.correo;
                model.Fecha = oTabla.fecha;
                model.Id = oTabla.id;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (masterEntities1 db = new masterEntities1())
                    {
                        var otabla = db.Tabla.Find(model.Id);
                        otabla.id = model.Id;
                        otabla.correo = model.Correo;
                        otabla.fecha = model.Fecha;
                        otabla.nombre = model.Nombre;

                        db.Entry(otabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("/Tabla");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public ActionResult Eliminar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (masterEntities1 db = new masterEntities1())
            {
                var oTabla = db.Tabla.Find(id);
                db.Tabla.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/Tabla");
        }
        }
}