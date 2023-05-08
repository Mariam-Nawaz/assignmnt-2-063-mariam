using assignmnt_2_063_mariam.Models;
using Microsoft.EntityFrameworkCore;

namespace assignmnt_2_063_mariam.Data
{
    public class appDb: DbContext
    {
        public appDb(DbContextOptions<appDb> db): base(db)
        {

        }
        public DbSet<user> users { get; set; }
    }
}
