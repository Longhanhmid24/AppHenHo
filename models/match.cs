namespace WinformGUI.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("matchs")]
    public partial class match
    {
        public int MatchID { get; set; }

        [StringLength(30)]
        public string SenderID { get; set; }

        [StringLength(30)]
        public string ReceiverID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Userr Userr { get; set; }

        public virtual Userr Userr1 { get; set; }
    }
}
