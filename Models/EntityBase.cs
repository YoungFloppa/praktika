using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class EntityBase
    {
        [Key]
        [Index]
        public string ID { get; set; }
        public string DateTime { get; set; }
    }
}
