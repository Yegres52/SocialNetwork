using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddingView
    {
        FriendService friendService;

        public FriendAddingView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var friendAddingData = new FriendAddingData();

            Console.Write("Введите почтовый адрес друга: ");
            friendAddingData.FriendEmail = Console.ReadLine();

            friendAddingData.UserId = user.Id;

            try
            {
                friendService.AddFriend(friendAddingData);

                SuccessMessage.Show("Пользователь успешно добавлен в друзья!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (FriendNotAddedException)
            {
                AlertMessage.Show("Произошла ошибка при добавлении в друзья!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла непредвиденная ошибка!");
            }

        }
    }
}
