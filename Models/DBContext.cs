using Microsoft.EntityFrameworkCore;

namespace master_bppm.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }


        public DbSet<XXB7_ESS_BPPM_ORACLE_DATA_V> XXB7_ESS_BPPM_ORACLE_DATA_V { get; set; }
        public DbSet<XXB7_ESS_BPPM_ORACLE_USER_V> XXB7_ESS_BPPM_ORACLE_USER_V { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<XXB7_ESS_BPPM_ORACLE_WR_WO_V>().HasNoKey();
        //}
    }
}
