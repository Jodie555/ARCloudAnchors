using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Assets.Scripts.DataObjects.Object
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
                return new Quaternion(rotationW, positionX, positionY, positionZ);
            }
        }
        public string tag;
        public GameObject gameObject;
        public string owner_UserID;
        public Dictionary<string, bool> members_UserID;

        public PlacedGameObject(string placedGameObjectID, string prefabName, Vector3 position, Quaternion rotation,
            string tag, GameObject gameObject, string owner_UserID, Dictionary<string, bool> members_UserID)
        {
            this.prefabName = prefabName;
            positionX = position.x;
            positionY = position.y;
            positionZ = position.z;
            rotationW = rotation.w;
            rotationX = rotation.x;
            rotationY = rotation.y;
            rotationZ = rotation.z;
            this.tag = tag;
            this.gameObject = gameObject;
            this.placedGameObjectID = placedGameObjectID;
            this.owner_UserID = owner_UserID;
            this.members_UserID = members_UserID;
        }

    }
}