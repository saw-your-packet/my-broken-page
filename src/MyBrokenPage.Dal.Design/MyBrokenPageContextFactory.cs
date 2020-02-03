using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyBrokenPage.Dal.Design
{
    public class MyBrokenPageContextFactory : IDesignTimeDbContextFactory<MyBrokenPageContext>
    {
        public MyBrokenPageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyBrokenPageContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(local);Initial Catalog=MyBrokenPage;Connect Timeout=30;Encrypt=False;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", b => b.MigrationsAssembly("MyBrokenPage.Dal.Design"));

            return new MyBrokenPageContext(optionsBuilder.Options);
        }
    }
}
