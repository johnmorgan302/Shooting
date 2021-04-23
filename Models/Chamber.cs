using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shooting
{
    class Chamber
    {
        [Key]
        public int ChamberID { get; set; }

        [Required]
        public string ChamberName { get; set; }

        public string Wiki { get; set; }

        // This creates a many to many relationship with firearms
        public virtual ICollection<Firearm> Firearms { get; set; }

        public virtual ICollection<LoadData> Loads { get; set; }

        public Chamber()
        {
            //enable ability to add loads for a
            //chambering
            this.Loads = new HashSet<LoadData>();
        }
    }
}