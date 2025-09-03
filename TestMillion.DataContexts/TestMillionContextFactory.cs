using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace TestMillion.DataContexts
{

 public class TestMillionContextFactory : IDesignTimeDbContextFactory<TestMillionContext>
    {
        
        public TestMillionContext CreateDbContext(string[] args)
        {
                DbContextOptionsBuilder<TestMillionContext> OptionsBuilder = new DbContextOptionsBuilder<TestMillionContext>();
               OptionsBuilder.UseSqlServer("");
            return new TestMillionContext(OptionsBuilder.Options);
        }
    }

}
