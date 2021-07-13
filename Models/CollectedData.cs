using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("CollectedData")]
    public class CollectedData : EntityBase
    {
        public int AdcValue { get; set; }
        public int Voltage { get; set; }

        public string ArduinoID { get; set; }
        [ForeignKey("ArduinoID")]
        public virtual LaborantID { get; set; }
    [ForeignKey("LaborantID")]
    public virtual Laborant Laborant { get; set;}

    }
}
