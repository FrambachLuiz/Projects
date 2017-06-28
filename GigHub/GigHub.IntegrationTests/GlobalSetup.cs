using GigHub.Persistence;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Data.Entity.Migrations;

namespace GigHub.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [SetUp]
        public void SetUp()
        {
            var configuration = new GigHub.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();

        }

        public void Seed()
        {
            var context = new ApplicationDbContext();
           // context.Users.Add
        }
    }
}
