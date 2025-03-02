namespace WinformGUI.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("report")]
    public partial class report
    {
        [Required]
        [StringLength(30)]
        public string Receiver { get; set; }

        [StringLength(50)]
        public string loai { get; set; }

        public string noidun { get; set; }

        [Column(TypeName = "date")]
        public DateTime? thoigian { get; set; }

        public int id { get; set; }

        [StringLength(30)]
        public string sender { get; set; }

        public virtual Userr Userr { get; set; }

        public virtual Userr Userr1 { get; set; }
    }
}
