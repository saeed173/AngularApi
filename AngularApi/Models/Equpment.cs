using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class Equpment
    {
        [Key]
        public long Equipment_ID { get; set; }

        public int EquipmentName_ID { get; set; }
        [ForeignKey("EquipmentName_ID")]
        public virtual EqupmentName eequpment { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(10)]
        public string Pyear { get; set; }

        [Required]
        [StringLength(10)]
        public string PurchaseTime { get; set; }

        public bool Active { get; set; }

        public string TechSpec { get; set; }

        public int Usage { get; set; }

    }
}
