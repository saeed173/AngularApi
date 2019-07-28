using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class EqupmentName
    {

        [Key]
        public int EquipmentName_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; }
        public virtual ICollection<Equpment> equpequpments { get; set; }
        public EqupmentName()
        {
            equpequpments = new List<Equpment>();
        }

    }
}
