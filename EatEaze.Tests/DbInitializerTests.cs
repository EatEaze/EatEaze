using EatEaze.DbHelpers;

namespace EatEaze.Tests
{
    public class DbInitializerTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void DbInitializerTest()
        {
            var result = DbInitializer.InitDatabase();
            Assert.That(result, Is.EqualTo(0));
        }
    }
}