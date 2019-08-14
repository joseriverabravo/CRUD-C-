using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUD.Models.ViewModels
{
    public class TablaViewModel
    {
        [Required]
        
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Nombre")]
        public String Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Correo Electronico")]
        public String Correo { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Fecha")]
        public String Fecha { get; set; }
        
    }
}