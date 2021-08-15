using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using HighlightingSystem;
using SDG.Unturned;
using Steamworks;

namespace sf.Utils
{
    public class Utilities : MonoBehaviour 
    {
        public static Camera mainCamera;
        public static Player mainPlayer;
        public static List<ulong> FriendsList = new List<ulong>();

        public static void AddFriend(Player player)
        {
            var steamid = (ulong)player.channel.owner.playerID.steamID;
            if (!FriendsList.Contains(steamid))
            {
                FriendsList.Add(steamid);
            }
        }
        public static void RemoveFriend(Player player)
        {
            var steamid = (ulong)player.channel.owner.playerID.steamID;
            if (FriendsList.Contains(steamid))
            {
                FriendsList.Remove(steamid);
            }
        }
        public static bool IsFriendly(Player player)
        {
            var steamid = (ulong)player.channel.owner.playerID.steamID;
            if (FriendsList.Contains(steamid) || player.quests.isMemberOfSameGroupAs(mainPlayer))
            {
                return true;
            }
            return false;
        }

     
    }

}
