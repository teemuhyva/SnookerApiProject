using SnookerApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnookerApiProject.Service {
    public interface IFriends {

        Friend FindFriendByNick(string nickName);
        Friend AddToFriend(Friend friend);

        List<Friend> ListAllFriends();
    }
}
