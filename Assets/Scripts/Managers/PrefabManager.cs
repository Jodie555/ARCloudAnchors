using Assets.Scripts.DataObjects.Object;
using Google.XR.ARCoreExtensions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    private ResolveCloudAnchorResult resolveCloudAnchorResult = null;

    private FirebaseInit firebaseInit = null;

    // Start is called before the first frame update
    void Start()
    {
        firebaseInit = GetComponent<FirebaseInit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveGameObjectsPosition()
    {
        ARDebugManager.Instance.LogInfo("saveGameObjectsPosition");

        //get all the prefab instances in the scene
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("TestingAnchor");
        foreach (GameObject gameObject in gameObjects)
        {
            //get the position of the prefab instance
            Vector3 position = gameObject.transform.position;
            //get the name of the prefab instance
            string name = gameObject.name;
            //save the position and name of the prefab instance
            //firebaseInit.saveGameObjectPosition(name, position);
            ARDebugManager.Instance.LogInfo("saveGameObjectsPosition");


        }
        //upload list of objects
        List<PlacedGameObject> list = new List<PlacedGameObject>();
        Dictionary<string, PlacedGameObject> dict = new Dictionary<string, PlacedGameObject>();

        var i = 0;
        foreach (GameObject gameObject in gameObjects)
        {
            //get the position of the prefab instance
            Vector3 position = gameObject.transform.position;
            //get the name of the prefab instance
            string name = gameObject.name;
            //save the position and name of the prefab instance
            //firebaseInit.saveGameObjectPosition(name, position);
            ARDebugManager.Instance.LogInfo("saveGameObjectsPosition");

            PlacedGameObject placedGameObject = new PlacedGameObject("placedGameObjectID", name, position, Quaternion.identity, gameObject.tag, gameObject, "owner_UserID", null);
            dict.Add("key_" + i.ToString(), placedGameObject);
            i++;
            list.Add(placedGameObject);

        }


        Assets.Scripts.DataObjects.Object.Room room = new Assets.Scripts.DataObjects.Object.Room("roomID1", dict, null, null, new DateTime(), null, new DateTime(), null);

        string listObjects = JsonConvert.SerializeObject(room);


        firebaseInit.uploadObject("testinWayID", room.roomID, listObjects);


        // for testing purpose
        string listObjectsGameObjects = JsonConvert.SerializeObject(list);
        firebaseInit.uploadObject("listPlacedObjects", listObjectsGameObjects);

    }


    public async void placeObject()
    {
        // get list of object
        string listObjects = await firebaseInit.GetObject("testinWayID", "roomID1");
        try
        {
            //List<PlacedGameObject> listpPlacedObject = JsonConvert.DeserializeObject<List<PlacedGameObject>>(listObjects);
            //ARDebugManager.Instance.LogInfo($"list placedObject {listpPlacedObject[0].position}");
            Assets.Scripts.DataObjects.Object.Room listPlacedObject = JsonConvert.DeserializeObject<Assets.Scripts.DataObjects.Object.Room>(listObjects);
            ARDebugManager.Instance.LogInfo($"list placedObject {listPlacedObject.placedGameObjects["key_0"].position}");

        }
        catch
        (System.Exception e)
        {
            ARDebugManager.Instance.LogInfo($"Error {e.Message}");
        }
    }


}
