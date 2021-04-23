using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shooting
{
    class LoadData
    {
        [Key]
        public int LoadID { get; set; }

        [Required]
        public string LoadName { get; set; }

        [Required]
        public string Projectile { get; set; }
        
        [Required]
        public float ProjectileWeight { get; set; }

        [Required]
        public string Propellent { get; set; }

        [Required]
        public float PropellentWeight { get; set; }

        [Required]
        public string Primer { get; set; }

        // The following two fields set a
        // one to many relationship to
        // Chamber
        public int ChamberID { get; set; }
        public virtual Chamber Chamber { get; set; }
    }
}