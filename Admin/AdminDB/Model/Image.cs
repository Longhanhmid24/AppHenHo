namespace AdminDB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Images
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Images()
        {
            dang_anh = new HashSet<dang_anh>();
        }

        [Required]
        [StringLength(30)]
        public string account_name { get; set; }

        public byte[] ImageData { get; set; }

        [Key]
        public int id_avt { get; set; }

        [StringLength(30)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dang_anh> dang_anh { get; set; }

        public virtual Userr Userr { get; set; }
    }
}
