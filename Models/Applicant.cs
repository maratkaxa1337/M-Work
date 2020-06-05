namespace Marat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Applicant")]
    public partial class Applicant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Applicant()
        {
            Frame = new HashSet<Frame>();
        }

        public int ID { get; set; }

        [Required]
        public string LasrstName { get; set; }

        [Required]
        public string FristName { get; set; }

        public string MiddleName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(20)]
        public string Gender { get; set; }

        public int Series { get; set; }

        public int Number { get; set; }

        public DateTime EmlpoymentDate { get; set; }

        [Required]
        public string Education { get; set; }

        public double TotalSalary { get; set; }

        [Required]
        public string Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Frame> Frame { get; set; }
    }
}
