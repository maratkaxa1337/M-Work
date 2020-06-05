namespace Marat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Frame")]
    public partial class Frame
    {
        public int ID { get; set; }

        public int ApplicantsID { get; set; }

        public int PositionID { get; set; }

        public int PlaymentsID { get; set; }

        public virtual Applicant Applicant { get; set; }

        public virtual Playment Playment { get; set; }

        public virtual Postiton Postiton { get; set; }
    }
}
