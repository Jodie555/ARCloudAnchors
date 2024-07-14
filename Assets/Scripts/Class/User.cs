using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacedGameObjectClass;

namespace UserClass
{

    public class User
    {
        public string name;
        public string email;
        public string password;
        public string createdAt;
        public string updatedAt;


        public User(string name, string email, string password, string createdAt, string updatedAt)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }


    }

}
