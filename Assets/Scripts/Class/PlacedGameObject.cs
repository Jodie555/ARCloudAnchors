using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace PlacedGameObjectClass
{
    public class PlacedGameObject
    {
        public string prefabName;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        public string tag;
        public GameObject gameObject;

        public PlacedGameObject(string prefabName, Vector3 position, Quaternion rotation, Vector3 scale, string tag, GameObject gameObject)
        {
            this.prefabName = prefabName;
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.tag = tag;
            this.gameObject = gameObject;
        }

    }
}