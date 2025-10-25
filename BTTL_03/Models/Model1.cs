using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTTL_03.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelsDuLieuNhanSu")
        {
        }

        public virtual DbSet<TBL_DEPARMENT> TBL_DEPARMENT { get; set; }
        public virtual DbSet<TBL_EMPLOYEE> TBL_EMPLOYEE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
