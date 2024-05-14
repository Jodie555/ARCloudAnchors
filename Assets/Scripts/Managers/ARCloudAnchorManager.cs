using DilmerGames.Core.Singletons;
using Google.XR.ARCoreExtensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using Unity.Services.CloudSave;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Collections.Generic;
using static UnityEngine.Networking.UnityWebRequest;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARSubsystems;
using Firebase.Database;
using PlacedGameObjectClass;
using Newtonsoft.Json;

public class UnityEventResolver : UnityEvent<Transform>{}

public class ARCloudAnchorManager : Singleton<ARCloudAnchorManager>
{
    [SerializeField]
    private Camera arCamera = null;

    [SerializeField]
    private float resolveAnchorPassedTimeout = 10.0f;

    private ARAnchorManager arAnchorManager = null;

    private ARAnchor pendingHostAnchor = null;

    private string anchorToResolve;

    private bool anchorUpdateInProgress = false;

    private bool anchorResolveInProgress = false;
    
    private float safeToResolvePassed = 5.0f;

    private UnityEventResolver resolver = null;

    private HostCloudAnchorPromise HostCloudAnchorPromise = null;   

    private HostCloudAnchorResult hostCloudAnchorResult = null;

    private ResolveCloudAnchorPromise resolveCloudAnchorPromise = null; 

    private ResolveCloudAnchorResult resolveCloudAnchorResult = null;

    private string cloudAnchorId = null;

    //private List<ARAnchor> aRAnchors = new List<ARAnchor>();

    //private int anchorHostedCount = 0;

    //private bool isListHosted = true;

    public bool isNewSceneResolved = false;

    private FirebaseInit firebaseInit;

    private string fixedID = "testinID";


    private async void Awake() 
    {
        resolver = new UnityEventResolver();   
        resolver.AddListener((t) => ARPlacementManager.Instance.ReCreatePlacement(t));
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        

    }

    private void Start()
    {
        firebaseInit = GetComponent<FirebaseInit>();
    }

    public async void SaveData(string anchorId)
    {

        firebaseInit.uploadData(fixedID, anchorId);
        ARDebugManager.Instance.LogInfo($"Saving data {string.Join(',', anchorId)}");


    }

    public async void saveListOfData(List<object> anchorIdList)
    {
        firebaseInit.uploadListData("testList", "anchor", anchorIdList);
    }   

    private async Task<string> GetAnchorIDCloud()
    {


        string anchorId = await firebaseInit.getData(fixedID);
        ARDebugManager.Instance.LogInfo($"testValue firebase {anchorId}");

        return anchorId;
    }

    public async void getListOfAnchors()
    {


        //Dictionary<string, object> listObject = await firebaseInit.getDict("testinID");
        //object vector3 = listObject["anchor0"];
        //ARDebugManager.Instance.LogInfo($"get vector3 {vector3}");
        //foreach (DataSnapshot item in listObject)
        //{
        //    ARDebugManager.Instance.LogInfo($"anchors ListedObject {item.Value}");
        //}


        //Dictionary<string, object> listObject = await firebaseInit.GetDictTest<Dictionary<string, object>>("testinWayID");
        //object vector3 = listObject["anchor0"];
        //ARDebugManager.Instance.LogInfo($"get vector3 {vector3}");

        string testObject = await firebaseInit.GetDictTest<string>("testcheckID");
        ARDebugManager.Instance.LogInfo($"get vector3 {testObject}");
        PlacedGameObject placedObject = JsonConvert.DeserializeObject<PlacedGameObject>(testObject);
        ARDebugManager.Instance.LogInfo($"placedObject {placedObject.position}");
        ARDebugManager.Instance.LogInfo($"next {placedObject.rotation}");




    }


    public async void resolveAnchor()
    {
        //arAnchorManager = GetComponent<ARAnchorManager>();
        //NewSceneResolve();
        var anchorId = await GetAnchorIDCloud();
        ARDebugManager.Instance.LogInfo($"can anchor ID {anchorId}");

        if (anchorId != "")
        {
            arAnchorManager = GetComponent<ARAnchorManager>();
            resolveCloudAnchorPromise = arAnchorManager.ResolveCloudAnchorAsync(anchorId);
            ARDebugManager.Instance.LogInfo($"Next scene can get  Cloud Anchor ID {resolveCloudAnchorPromise}");

            StartCoroutine(ResolvePromise(resolveCloudAnchorPromise));
            ARDebugManager.Instance.LogInfo("Resolved");

        }
    }





    private Pose GetCameraPose()
    {
        return new Pose(arCamera.transform.position,
            arCamera.transform.rotation);
    }

#region Anchor Cycle

    public void QueueAnchor(ARAnchor arAnchor)
    {
        pendingHostAnchor = arAnchor;
    }


    //public void QueueAnchorList(List<ARAnchor> arAnchorList)
    //{
    //    aRAnchors = arAnchorList;
    //}


    private IEnumerator CheckHostCloudAnchorPromise(HostCloudAnchorPromise promise)
    {
       
        yield return promise;
        if (promise.State == PromiseState.Cancelled) yield break;
        hostCloudAnchorResult = promise.Result;
        /// Use the result of your promise here.

        cloudAnchorId = hostCloudAnchorResult.CloudAnchorId;
        ARDebugManager.Instance.LogInfo($"Cloud Anchor ID new {cloudAnchorId}");
        anchorUpdateInProgress = true;

    }

    //private IEnumerator CheckListHostCloudAnchorPromise(HostCloudAnchorPromise promise)
    //{

    //    yield return promise;
    //    if (promise.State == PromiseState.Cancelled) yield break;
    //    hostCloudAnchorResult = promise.Result;
    //    /// Use the result of your promise here.

    //    cloudAnchorId = hostCloudAnchorResult.CloudAnchorId;
    //    ARDebugManager.Instance.LogInfo($"Cloud Anchor ID new {cloudAnchorId}");
    //    isListHosted = true;
    //    anchorHostedCount++;
    //}


    public void HostAnchor()
    {

        ARDebugManager.Instance.LogInfo($"HostAnchor executing");
        ARDebugManager.Instance.LogInfo($"Camera Pose {GetCameraPose()}");
        ARDebugManager.Instance.LogInfo($"Anchor transform position {pendingHostAnchor.transform.position}");

        FeatureMapQuality quality =
            arAnchorManager.EstimateFeatureMapQualityForHosting(GetCameraPose());

        ARDebugManager.Instance.LogInfo($"quality {quality}");

        HostCloudAnchorPromise =  arAnchorManager.HostCloudAnchorAsync(pendingHostAnchor, 1);
        StartCoroutine(CheckHostCloudAnchorPromise(HostCloudAnchorPromise));


    }

    //public void HostAnchorList()
    //{
    //    ARDebugManager.Instance.LogInfo($"host a list of Anchors");
    //    foreach(ARAnchor anchor in aRAnchors)
    //    {
    //        if (isListHosted)
    //        {
    //            var promise = arAnchorManager.HostCloudAnchorAsync(anchor, 1);
    //            isListHosted = false;
    //            StartCoroutine(CheckListHostCloudAnchorPromise(promise));
    //        }

    //    }
    //    ARDebugManager.Instance.LogInfo($"number of hosted anchor {anchorHostedCount}");
        
    //}


    private IEnumerator ResolvePromise(ResolveCloudAnchorPromise promise)
    {
        ARDebugManager.Instance.LogInfo($"new state {promise.State}");

        yield return promise;
        if (promise.State == PromiseState.Cancelled) yield break;
        resolveCloudAnchorResult = promise.Result;
        /// Use the result of your promise here.

        var resultAnchor = resolveCloudAnchorResult.Anchor;
        anchorResolveInProgress = true;
        ARDebugManager.Instance.LogInfo($"resultAnchor new {resultAnchor.transform.position}");
    }

    public async void SaveCloudAnchorID()
    {

        ARDebugManager.Instance.LogInfo($"saved Cloud Anchor ID {cloudAnchorId}");
        SaveData(cloudAnchorId);

    }

    private void CheckHostingProgress()
    {
        CloudAnchorState cloudAnchorState = hostCloudAnchorResult.CloudAnchorState;
        if (cloudAnchorState == CloudAnchorState.Success)
        {
            ARDebugManager.Instance.LogError("Anchor successfully hosted");
            
            anchorUpdateInProgress = false;

            // keep track of cloud anchors added
            anchorToResolve = hostCloudAnchorResult.CloudAnchorId;
            ARDebugManager.Instance.LogError($"get the host cloud Anchor Result CloudAnchorID : {hostCloudAnchorResult.CloudAnchorId}");
        }
        else if(cloudAnchorState != CloudAnchorState.TaskInProgress)
        {
            ARDebugManager.Instance.LogError($"Fail to host anchor with state: {cloudAnchorState}");
            anchorUpdateInProgress = false;
        }
    }



    private void CheckResolveProgress()
    {
        CloudAnchorState cloudAnchorState = resolveCloudAnchorResult.CloudAnchorState;

        ARDebugManager.Instance.LogInfo($"ResolveCloudAnchor state {cloudAnchorState}");

        if (cloudAnchorState == CloudAnchorState.Success)
        {

            //resolver.Invoke(resolveCloudAnchorResult.Anchor.transform);

            //ARPlacementManager.Instance.RemovePlacements();
            ARPlacementManager.Instance.placeGameObject(resolveCloudAnchorResult.Anchor);

            anchorResolveInProgress = false;

            ARDebugManager.Instance.LogInfo($"CloudAnchorId: {resolveCloudAnchorResult.Anchor.transform.position} resolved");
        }
        else if (cloudAnchorState != CloudAnchorState.TaskInProgress)
        {
            ARDebugManager.Instance.LogError($"Fail to resolve Cloud Anchor with state: {cloudAnchorState}");

            anchorResolveInProgress = false;
        }
    }


    #endregion

    void Update()
    {

        // check progress of new anchors created
        if (anchorUpdateInProgress)
        {
            CheckHostingProgress();
            return;
        }

        if(anchorResolveInProgress && safeToResolvePassed <= 0)
        {
            // check evey (resolveAnchorPassedTimeout)
            safeToResolvePassed = resolveAnchorPassedTimeout;

            ARDebugManager.Instance.LogInfo($"Resolving AnchorId: {anchorToResolve}");
            CheckResolveProgress();

        }
        else
        {
            safeToResolvePassed -= Time.deltaTime * 1.0f;
        }



    }


}
