using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Entities
{
    public class Productos
    {

               [Key]
                public string CodigoProd { get; set; }
                public string NombreProd { get; set; }
                public string Descripcion { get; set; }
                public decimal Precio { get; set; }
         

    }
}
