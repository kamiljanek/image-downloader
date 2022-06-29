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
        [Fact()]
        public void UserGmailTest_ForGmailPasswordContainsMoreThan_7_AndLessThan_101_Chars_UpdatesProperty()
        {
            //arrange

            var userGmail = new UserGmail();

            //act

            userGmail.GmailPassword = "something";

            //assert

            userGmail.GmailPassword.Should().NotBeEmpty();
        }
        [Fact()]
        public void UserGmailTest_ForGmailPasswordContainsLessThan_7_Chars_DoesntUpdateProperty()
        {
            //arrange

            var userGmail = new UserGmail();

            //act

            userGmail.GmailPassword = "some";

            //assert

            userGmail.GmailPassword.Should().BeNullOrEmpty();
        }
    }
}
