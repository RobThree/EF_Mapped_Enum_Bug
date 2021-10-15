using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EF_Mapped_Enum_Bug
{
    public class TestContext : DbContext
    {
        public virtual DbSet<Customer> Customers => Set<Customer>();

        public TestContext(DbContextOptions<TestContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
