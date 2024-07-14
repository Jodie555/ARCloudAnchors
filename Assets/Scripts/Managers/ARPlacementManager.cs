using System.Collections.Generic;
using DilmerGames.Core.Singletons;
using Google.XR.ARCoreExtensions;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using PlacedGameObjectClass;
using Newtonsoft.Json;
using System;
using UnityEngine.UIElements;

[RequireComponent(typeof(ARRaycastManager))]
public class ARPlacementManager : Singleton<ARPlacementManager>
{ 
    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private GameObject placedPrefab = null;

    private GameObject placedGameObject = null;

    private ARRaycastManager arRaycastManager = null;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private ARAnchorManager arAnchorManager = null;

    private GameObjectsManager gameObjectsManager = null;

    private AnchorListManager anchorListManager = null;

    private FirebaseInit firebaseInit = null;

    private bool enablePlacement = false;

    void Awake() 
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arAnchorManager = GetComponent<ARAnchorManager>();
        gameObjectsManager = GetComponent<GameObjectsManager>();
        anchorListManager = GetComponent<AnchorListManager>();
        firebaseInit = GetComponent<FirebaseInit>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                touchPosition = touch.position;

                bool isOverUI = touchPosition.IsPointOverUIObject();

                return isOverUI ? false : true;
            }
        }

        touchPosition = default;

        return false;
    }

    public void changePlacedPrefab(string tagName)
    {
        ARDebugManager.Instance.LogInfo($"before changed placed Prefab");
        placedPrefab = gameObjectsManager.getGameObjectByName(tagName);
        //placedPrefab = GameObject.FindGameObjectWithTag(tagName);
        ARDebugManager.Instance.LogInfo($"changed placePrefab {placedPrefab}");
        
    }

    public void RemovePlacements()
    {
        if (placedGameObject != null)
        {
            Destroy(placedGameObject);
            placedGameObject = null;

        }

    }


    public void TogglePlacement()
    {
        enablePlacement = !enablePlacement;
    }

    void Update()
    {

        if (!enablePlacement) return;

        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        //if(placedGameObject != null)
        //    return;

        //if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        //{
        //    var hitPose = hits[0].pose;
        //    ARDebugManager.Instance.LogInfo($"Hit Pose placeManager {hitPose}");
        //    placedGameObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        //    ARDebugManager.Instance.LogInfo($"HostAnchor executing");
        //    var anchor = arAnchorManager.AddAnchor(new Pose(hitPose.position, hitPose.rotation));
        //    placedGameObject.transform.parent = anchor.transform;
        //    ARDebugManager.Instance.LogInfo($"anchor Pose {anchor.transform.position}");

        //    // this won't host the anchor just add a reference to be later host it
        //    ARCloudAnchorManager.Instance.QueueAnchor(anchor);
        //}


        Vector3 newTouchPosition = arCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0.3f));
        ARDebugManager.Instance.LogInfo($"Hit Pose placeManager {newTouchPosition}");
        placedGameObject = Instantiate(placedPrefab, newTouchPosition, new Quaternion());
        ARDebugManager.Instance.LogInfo($"HostAnchor executing");
        var anchor = arAnchorManager.AddAnchor(new Pose(newTouchPosition, new Quaternion()));
        placedGameObject.transform.parent = anchor.transform;
        ARDebugManager.Instance.LogInfo($"anchor Pose {anchor.transform.position}");

        // this won't host the anchor just add a reference to be later host it
        ARCloudAnchorManager.Instance.QueueAnchor(anchor);

        var testPlacedGameObject = new PlacedGameObject("gameObject1","Character", anchor.transform.position, anchor.transform.rotation, null, null,null, null);


        anchorListManager.AddPlacedGameObject(testPlacedGameObject);
        ARDebugManager.Instance.LogInfo($"Added anchorListManager {anchorListManager.placedGameObjects}");


        var position = anchorListManager.placedGameObjects[0].position;
        ARDebugManager.Instance.LogInfo($"get back pos {position}");


    }


    public void uploadAnchorList()
    {

        //upload one object
        try
        {
            string s = JsonConvert.SerializeObject(anchorListManager.placedGameObjects[0]);
            ARDebugManager.Instance.LogInfo($"result placed game object {s}");
            firebaseInit.uploadObject("testcheckID", s);
        }
        catch (Exception e)
        {
            ARDebugManager.Instance.LogInfo($"Error {e.Message}");
        }

        //upload list of objects
        List<PlacedGameObject> list = new List<PlacedGameObject>();
        Dictionary<string, PlacedGameObject> dict = new Dictionary<string, PlacedGameObject>();
        for (int i = 0; i < anchorListManager.placedGameObjects.Count; i++)
        {
            ARDebugManager.Instance.LogInfo($"Placed Game Object {anchorListManager.placedGameObjects[i].position}");
            list.Add(anchorListManager.placedGameObjects[i]);

            //object placedobject = anchorListManager.placedGameObjects[i];
            string test = JsonConvert.SerializeObject(anchorListManager.placedGameObjects[i]);

            firebaseInit.uploadObject("testValue", i.ToString(), test);
            dict.Add("key_"+i.ToString(), anchorListManager.placedGameObjects[i]);

        }
        //firebaseInit.uploadListData("testinWayID", "anchor", list);

        RoomClass.Room room = new RoomClass.Room("roomID1", dict, null, null, new DateTime(), null, new DateTime(), null);

        string listObjects = JsonConvert.SerializeObject(room);


        firebaseInit.uploadObject("testinWayID", room.roomID, listObjects);

    }

    public void ReCreatePlacement(Transform transform)
    {
        placedGameObject = Instantiate(placedPrefab, transform.position, transform.rotation);
        placedGameObject.transform.parent = transform;
    }




    public void placeGameObject(ARCloudAnchor anchorCloudObject)
    {
        ARDebugManager.Instance.LogInfo($"Get Back Position {anchorCloudObject.transform.position}");

        placedGameObject = Instantiate(placedPrefab, anchorCloudObject.transform.position, anchorCloudObject.transform.rotation);
        placedGameObject.transform.parent = anchorCloudObject.transform;
        ARDebugManager.Instance.LogInfo($"Finished");
    }

    public void placeGameObject(ARCloudAnchor receivedAnchor,List<PlacedGameObject> listPlacedObjects)
    {

        PlacedGameObject lastPlacedObject = listPlacedObjects[listPlacedObjects.Count - 1];

        Vector3 distanceDifference = lastPlacedObject.position - receivedAnchor.transform.position;

        //for loop of listPlacedObjects
        for (int i = 0; i < listPlacedObjects.Count; i++)
        {
            ARDebugManager.Instance.LogInfo($"Get Back Position {listPlacedObjects[i].position}");

            Vector3 newPosition = listPlacedObjects[i].position - distanceDifference;

            placedGameObject = Instantiate(placedPrefab, newPosition, listPlacedObjects[i].rotation);
            placedGameObject.transform.parent = receivedAnchor.transform;

            ARDebugManager.Instance.LogInfo($"name {placedGameObject.name}");
            ARDebugManager.Instance.LogInfo($"layer {placedGameObject.layer}");


        }
        ARDebugManager.Instance.LogInfo($"Finished");

    }

}