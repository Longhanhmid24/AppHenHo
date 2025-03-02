namespace WinformGUI.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dang_anh
    {
        public int id_avt { get; set; }

        public byte[] images { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_dang { get; set; }

        [Key]
        public int id_anh { get; set; }

        public virtual Images Image { get; set; }
    }
}
