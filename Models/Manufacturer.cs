using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shooting
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerID { get; set; }

        [Required]
        [Display(Name="Manufacturer Name")]
        public string ManufacturerName { get; set; }

        public string Logo { get; set; }

        public string Wiki { get; set; }

        [Display(Name="Web Site")]
        public string WebSite { get; set; }

        public virtual ICollection<Firearm> Firearms { get; set; }

        public Manufacturer()
        {
            this.Firearms = new HashSet<Firearm>();
        }
    }
}