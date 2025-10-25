namespace BTTL_03.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_EMPLOYEE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(20)]
        public string ImgFace { get; set; }

        public int? Deptld { get; set; }

        public virtual TBL_DEPARMENT TBL_DEPARMENT { get; set; }
    }
}
