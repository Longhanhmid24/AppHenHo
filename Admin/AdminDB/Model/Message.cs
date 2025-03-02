namespace AdminDB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Sender { get; set; }

        [Required]
        [StringLength(30)]
        public string Receiver { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime? Timestamp { get; set; }

        public virtual Userr Userr { get; set; }

        public virtual Userr Userr1 { get; set; }
    }
}
