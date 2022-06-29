using FluentAssertions;
using Xunit;

namespace Model.Tests
{
    public class UserGmailTests
    {
        [Fact()]
        public void UserGmailTest_ForGmailAddressContainsGmail_com_UpdatesProperty()
        {
            //arrange
            
            var userGmail = new UserGmail();

            //act

            userGmail.GmailAddress = "something@gmail.com";

            //assert

            userGmail.GmailAddress.Should().NotBeEmpty();
        }
        [Fact()]
        public void UserGmailTest_ForGmailAddressNotContainsGmail_com_DoesntUpdateProperty()
        {
            //arrange

            var userGmail = new UserGmail();

            //act

            userGmail.GmailAddress = "something";

            //assert

            userGmail.GmailAddress.Should().BeNullOrEmpty();
        }
        [Theory()]
        [InlineData("somethin")]
        [InlineData("somethingsomethingsomethingsomethingsomethingsomethingsomething")]
        public void UserGmailTest_ForGmailPasswordContainsMoreThan7AndLessThan101Chars_UpdatesProperty(string gmailPassword)
        {
            //arrange

            var userGmail = new UserGmail();

            //act

            userGmail.GmailPassword = gmailPassword;

            //assert

            userGmail.GmailPassword.Should().NotBeNullOrEmpty();
        }
        [Theory()]
        [InlineData("")]
        [InlineData("some")]
        [InlineData("somethi")]
        public void UserGmailTest_ForGmailPasswordContainsLessOrEqualThan7Chars_DoesntUpdateProperty(string gmailPassword)
        {
            //arrange

            var userGmail = new UserGmail();

            //act

            userGmail.GmailPassword = gmailPassword;

            //assert

            userGmail.GmailPassword.Should().BeNullOrEmpty();
        }
    }
}
