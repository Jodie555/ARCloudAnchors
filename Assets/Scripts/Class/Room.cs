using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacedGameObjectClass;
using System;

namespace RoomClass
{

    public class Room
    {   
        public string roomID;
        public Dictionary<string,PlacedGameObject> placedGameObjects;
        public Dictionary<string, bool> members_UserID;
        public string owner_UserID;
        public DateTime createdAt;
        public string createdBy;
        public DateTime updatedAt;
        public string updatedBy;

        //public Room(string roomID, Dictionary<string, PlacedGameObject> placedGameObjects)
        //{   
        //    this.roomID = roomID;
        //    this.placedGameObjects = placedGameObjects;
        //}

        public Room(string roomID, Dictionary<string, PlacedGameObject> placedGameObjects, Dictionary<string, bool> members_UserID, string owner_UserID, DateTime createdAt, string createdBy, DateTime updatedAt, string updatedBy)
        {
            this.roomID = roomID;
            this.placedGameObjects = placedGameObjects;
            this.members_UserID = members_UserID;
            this.owner_UserID = owner_UserID;
            this.createdAt = createdAt;
            this.createdBy = createdBy;
            this.updatedAt = updatedAt;
            this.updatedBy = updatedBy;
        }

    }

}

