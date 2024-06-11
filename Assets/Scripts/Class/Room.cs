using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacedGameObjectClass;

namespace RoomClass
{

    public class Room
    {
        public List<PlacedGameObject> placedGameObjects;
        public Room(List<PlacedGameObject> placedGameObjects)
        {
            this.placedGameObjects = placedGameObjects;
        }
    }

}

