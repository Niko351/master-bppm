using Microsoft.EntityFrameworkCore;

namespace master_bppm.Models
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {

        }
        public DbSet<XXB7_ESS_BPPM_MASTER_DATA> XXB7_ESS_BPPM_MASTER_DATA { get; set; }
        public DbSet<XXB7_ESS_BPPM_LOG_MASTER_DATA> XXB7_ESS_BPPM_LOG_MASTER_DATA { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=myserver;Database=mydatabase;User=myuser;Password=mypassword;");
        //}

    }

}
