using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shooting
{
    public class Firearm
    {
        [Key]
        public int FirearmID { get; set; }

        [Required]
        public string FirearmName { get; set; }

        public string Wiki { get; set; }
        
        public string LeftSide { get; set; }
        
        public string RightSide { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        // The following Two fields create a one
        // to many relationship with Manufacturer
        public int ManufacturerID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        // Create a Many to Many Link with Chambers

        public virtual ICollection<Chamber> Chambers { get; set; }
    }
}