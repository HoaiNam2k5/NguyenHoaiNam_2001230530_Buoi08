namespace BTM01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINTUC")]
    public partial class TINTUC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTin { get; set; }

        public int? IDLoai { get; set; }

        [StringLength(100)]
        public string TieuDeTin { get; set; }

        [Column(TypeName = "ntext")]
        public string Noidungtin { get; set; }

        public virtual THELOAITIN THELOAITIN { get; set; }
    }
}
