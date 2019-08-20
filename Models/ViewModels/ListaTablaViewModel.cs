using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class ListaTablaViewModel
    {
        //campos de la tabla
        public int Id { get; set; }
        public String Nombre{ get; set; }
        public String Correo { get; set; }
        public String Fecha { get; set; }
    }
}