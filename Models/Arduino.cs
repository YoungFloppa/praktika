using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Arduino")]
   public class Arduino: EntityBase
    {
        [Column(TypeName ="NVARCHAR")]
        public string ArduinoName { get; set; }
        public int ControllerFrequency { get; set; }
        public string CreationDate { get; set; }
    }
}
