namespace AdminDB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class block
    {
        public int BlockId { get; set; }

        [Required]
        [StringLength(30)]
        public string SenderId { get; set; }

        [Required]
        [StringLength(30)]
        public string ReceiverId { get; set; }

        public virtual Userr Userr { get; set; }

        public virtual Userr Userr1 { get; set; }
    }
}
