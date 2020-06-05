namespace Marat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Postiton")]
    public partial class Postiton
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postiton()
        {
            Frame = new HashSet<Frame>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(140)]
        public string Title { get; set; }

        public double Salary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Frame> Frame { get; set; }
    }
}
