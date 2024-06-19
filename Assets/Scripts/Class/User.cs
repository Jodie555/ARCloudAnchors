using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacedGameObjectClass;

namespace UserClass
{

    public class User
    {
        public Dictionary<string,RoomClass.Room> room;
        public string name;
        public string email;
        public string password;
        public string createdAt;
        public string updatedAt;


        public User(Dictionary<string, RoomClass.Room> room)
        {
            this.room = room;
        }


    }

}

