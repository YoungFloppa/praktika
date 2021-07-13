using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Laborants")]
   public class Laborant: EntityBase
    {
        [Column(TypeName = "NVARCHAR")]
        public string FirstName { get; set; }
        [Column(TypeName = "NVARCHAR")]
        public int SecondName { get; set; }
    }
}
