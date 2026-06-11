using SocialNetwork.BLL.Models;

namespace SocialNetwork.Tests
{
    public class FriendAddingDataTests
    {
        [Fact]
        public void DataStored()
        {
            var friendAddingData = new FriendAddingData();

            friendAddingData.UserId = 1;
            friendAddingData.FriendEmail = "friend@mail.ru";

            Assert.Equal(1, friendAddingData.UserId);
            Assert.Equal("friend@mail.ru", friendAddingData.FriendEmail);
        }
    }
}
