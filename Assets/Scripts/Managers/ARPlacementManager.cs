using System.Collections.Generic;
using DilmerGames.Core.Singletons;
using Google.XR.ARCoreExtensions;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using PlacedGameObjectClass;
using Newtonsoft.Json;
using System;

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

        var testPlacedGameObject = new PlacedGameObject("Character", anchor.transform.position, anchor.transform.rotation, null, null);


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


        List<object> list = new List<object>();
        for (int i = 0; i < anchorListManager.placedGameObjects.Count; i++)
        {
            ARDebugManager.Instance.LogInfo($"Placed Game Object {anchorListManager.placedGameObjects[i].position}");
            list.Add(anchorListManager.placedGameObjects[i]);

            //object placedobject = anchorListManager.placedGameObjects[i];







        }
        //firebaseInit.uploadListData("testinWayID", "anchor", list);
        string listObjects = JsonConvert.SerializeObject(list);

        firebaseInit.uploadObject("testinWayID", listObjects);

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
}