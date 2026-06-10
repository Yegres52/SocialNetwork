using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public void AddFriend(FriendAddingData friendAddingData)
        {
            if (String.IsNullOrEmpty(friendAddingData.FriendEmail))
                throw new ArgumentNullException();

            var friendUserEntity = this.userRepository.FindByEmail(friendAddingData.FriendEmail);
            if (friendUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddingData.UserId,
                friend_id = friendUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new FriendNotAddedException();
        }
    }
}
