namespace WinformGUI.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class thong_tin_user
    {
        [Key]
        [StringLength(30)]
        public string account_name { get; set; }

        [StringLength(50)]
        public string hovaten { get; set; }

        [StringLength(100)]
        public string gmail { get; set; }

        [StringLength(5)]
        public string gioitinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        [StringLength(200)]
        public string diachi { get; set; }

        public virtual Userr Userr { get; set; }
    }
}
