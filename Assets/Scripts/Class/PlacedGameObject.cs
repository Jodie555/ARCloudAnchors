using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace PlacedGameObjectClass
{
    public class PlacedGameObject
    {
        public string placedGameObjectID;

        public float positionX;
        public float positionY;
        public float positionZ;

        public float rotationW;
        public float rotationX;
        public float rotationY;
        public float rotationZ;


        public string prefabName;
        [JsonIgnore]
        public Vector3 position
        {
            get
            {
                return new Vector3(positionX, positionY, positionZ);
            }
        }
        [JsonIgnore]
        public Quaternion rotation
        {
            get
            {
                return new Quaternion(rotationW,positionX, positionY, positionZ);
            }
        }
        public string tag;
        public GameObject gameObject;
        public string owner_UserID;
        public Dictionary<string, bool> members_UserID;

        public PlacedGameObject(string placedGameObjectID, string prefabName, Vector3 position, Quaternion rotation, 
            string tag, GameObject gameObject,string owner_UserID, Dictionary<string, bool> members_UserID)
        {
            this.prefabName = prefabName;
            this.positionX = position.x;
            this.positionY = position.y;
            this.positionZ = position.z;
            this.rotationW = rotation.w;
            this.rotationX = rotation.x;
            this.rotationY = rotation.y;
            this.rotationZ = rotation.z;
            this.tag = tag;
            this.gameObject = gameObject;
            this.placedGameObjectID = placedGameObjectID;
            this.owner_UserID = owner_UserID;
            this.members_UserID = members_UserID;
        }

    }
}