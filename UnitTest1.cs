using Xunit;
using IIG.PasswordHashingUtils;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private static string _newsalt = "here goes the salt";
        private static string _password = "here goes the password";
        private static string _password2 = "this is another password";
        private static uint _modAdler32 = 65521;
        [Fact]
        private void TestGetHash()
        {
            Assert.NotNull(PasswordHasher.GetHash(_password));
        }
        [Fact]
        private void TestPasswordSaltRelation()
        {
            Assert.Equal(PasswordHasher.GetHash(_password), PasswordHasher.GetHash(_password));
        }
        [Fact]
        private void TestHashDifference()
        {
            Assert.NotEqual(PasswordHasher.GetHash(_password), PasswordHasher.GetHash(_password2));
        }
        [Fact]
        private void TestNewSaltWithInit()
        {
            string withOldSalt = PasswordHasher.GetHash(_password);
            PasswordHasher.Init(_newsalt, _modAdler32);
            string withNewSalt = PasswordHasher.GetHash(_password);
            Assert.NotEqual(withOldSalt, withNewSalt);
        }
    }
}
