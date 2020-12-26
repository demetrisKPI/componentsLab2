using Xunit;
using IIG.PasswordHashingUtils;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private static string _newsalt = "here goes the salt";
        private static string _password = "here goes the password";
        private static string _PaSsWoRd = "HeRe GoEs ThE PaSsWoRd";
        private static string _password2 = "this is another password";
        private static uint _modAdler32 = 65521;

        [Fact]
        private void TestGetHash()
        {
            Assert.NotNull(PasswordHasher.GetHash(_password));
        }
        [Fact]
        private void TestSpecialSymbols()
        {
            string _symbols = "!@#$%^&*()_+-=,./;'[]|}{:";
            Assert.NotNull(PasswordHasher.GetHash(_symbols, _symbols));
        }
        [Fact]
        private void TestCaseSensitive()
        {
            Assert.NotEqual(PasswordHasher.GetHash(_password), PasswordHasher.GetHash(_PaSsWoRd));
        }
        [Fact]
        private void TestPasswordLength()
        {
            string _long = "text";

            for (int i = 0; i < 10000; i++)_long += "text";

            Assert.NotNull(PasswordHasher.GetHash(_long));
        }        
        [Fact]
        private void TestStringEmpty()
        {
            Assert.NotNull(PasswordHasher.GetHash(string.Empty, string.Empty));
        }
        [Fact]
        private void TestPasswordSaltRelationDefaultSalt()
        {
            Assert.Equal(PasswordHasher.GetHash(_password), PasswordHasher.GetHash(_password));
        }
        [Fact]
        private void TestPasswordSaltRelationCustomSalt()
        {
            Assert.Equal(PasswordHasher.GetHash(_password, _newsalt), PasswordHasher.GetHash(_password, _newsalt));
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
        [Fact]
        private void TestNewSaltWithoutInit()
        {
            string withOldSalt = PasswordHasher.GetHash(_password);
            string withNewSalt = PasswordHasher.GetHash(_password, "another salt");
            Assert.NotEqual(withOldSalt, withNewSalt);
        }
        [Fact]
        private void TestSaltEquivalenceUsingInit()
        {
            string withoutInit = PasswordHasher.GetHash(_password, _newsalt);
            PasswordHasher.Init(_newsalt, _modAdler32);
            string withInit = PasswordHasher.GetHash(_password);
            Assert.Equal(withoutInit, withInit);
        }
        [Fact]
        private void TestAdlerInt()
        {
            Assert.NotEqual(PasswordHasher.GetHash(_password, _newsalt), PasswordHasher.GetHash(_password, _newsalt, (uint)1));
        }
        [Fact]
        private void TestAdlerUint()
        {
            Assert.Equal(PasswordHasher.GetHash(_password, _newsalt), PasswordHasher.GetHash(_password, _newsalt, 1234567890));
        }
    }
}
