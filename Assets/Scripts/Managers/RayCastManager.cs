using DilmerGames.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class RayCastManager : Singleton<RayCastManager>
{

    [SerializeField]
    private Camera arCamera = null;
    GameObject controlledUnit = null;


    int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        int tapCount = Input.touchCount;
        Ray ray;
        Vector3 touchPosition;

        for (int i = 0; i < tapCount; i++)
        {

            Touch touch = Input.GetTouch(i);
            //touchPosition = arCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 0.3f));
            touchPosition = arCamera.ScreenToWorldPoint(touch.position);

            ARDebugManager.Instance.LogInfo($"touched  : {touchPosition}");


            if (touch.phase == TouchPhase.Began)
            {
                
                ray = arCamera.ScreenPointToRay(touch.position);


                if (Physics.Raycast(ray, out hit))
                {

                    try
                    {

                        controlledUnit = hit.transform.gameObject;
                        ARDebugManager.Instance.LogInfo($"name ff : {hit.transform.gameObject.name}");
                        //touchPosition = arCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
                        //controlledUnit.transform.position = touchPosition;

                    }
                    catch (System.Exception e)
                    {
                        ARDebugManager.Instance.LogInfo($"error {e.Message}");
                    }

                }

            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {

                ARDebugManager.Instance.LogInfo($"Moved=");
                touchPosition = arCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 0.3f));
                controlledUnit.transform.position = touchPosition;
                ARDebugManager.Instance.LogInfo($"Moved touched  : {touchPosition}");
            }
            else if (touch.phase == TouchPhase.Ended)
            {
            }
        }





        //if (!TryGetTouchPosition(out Vector2 touchPosition))
        //    return;

        //GameObject controlledUnit = null;
        //RaycastHit hit;
        //Ray ray = arCamera.ScreenPointToRay(touchPosition);

        //ARDebugManager.Instance.LogInfo($"touched  : {touchPosition}");

        

        //if (Physics.Raycast(ray, out hit))
        //{

        //    try
        //    {
        //        //ARDebugManager.Instance.LogInfo($"current position: {hit.transform.gameObject.transform.position}");
        //        //hit.transform.gameObject.transform.position = new Vector3(hit.transform.gameObject.transform.position.x + 10f, hit.transform.gameObject.transform.position.y + 10f, hit.transform.gameObject.transform.position.z + 10f);
        //        //ARDebugManager.Instance.LogInfo($"newposition: {hit.transform.gameObject.transform.position}");
        //        //ARDebugManager.Instance.LogInfo($"tag: {hit.transform.gameObject.tag}");

        //        controlledUnit = hit.transform.gameObject;

        //        ////controlledUnit.SetActive(false);
        //        //controlledUnit.transform.transform.position = new Vector3(0, 0, 0);
        //        //controlledUnit.transform.position = new Vector3(0, 0, 0);
        //        ARDebugManager.Instance.LogInfo($"name ff : {hit.transform.gameObject.name}");

        //    }
        //    catch (System.Exception e)
        //    {
        //        ARDebugManager.Instance.LogInfo($"error {e.Message}");
        //    }

        //}
        //else
        //{
        //    List<GameObject> objectsInScene = new List<GameObject>();
        //    GameObject[] _allObjects = SceneManager.GetSceneByName("NewScene").GetRootGameObjects();
        //    string names = "";


        //    foreach (GameObject obj in _allObjects)
        //    {
        //        objectsInScene.Add(obj);
        //        GetChildObjects(obj.transform, ref objectsInScene);
        //    }


        //    foreach (GameObject obj in objectsInScene)
        //    {
        //        if (obj.name.Contains("Charact"))
        //        {
        //            //obj.transform.transform.position = new Vector3(0, 0, 0);
        //            //obj.SetActive(false);
        //            ARDebugManager.Instance.LogInfo($"get the object I want");
        //            //go.transform.position = new Vector3(0, 0, 0);

        //        }

        //        names += obj.name + " ";
        //    }
        //    //ARDebugManager.Instance.LogInfo($"names {names}");

        //}

    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchPosition = touch.position;

                bool isOverUI = touchPosition.IsPointOverUIObject();

                return isOverUI ? false : true;
            }
        }

        touchPosition = default;

        return false;
    }

    void GetChildObjects(Transform parent, ref List<GameObject> objectsList)
    {
        foreach (Transform child in parent)
        {
            objectsList.Add(child.gameObject);
            GetChildObjects(child, ref objectsList); // Recursively find children
        }
    }

    //void tounchChange()
    //{
    //    int tapCount = Input.touchCount > 1 && lineSettings.allowMultiTouch ? Input.touchCount : 1;
    //    for (int i = 0; i < tapCount; i++)
    //    {

    //        Touch touch = Input.GetTouch(i);
    //        Vector3 touchPosition = arCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, lineSettings.distanceFromCamera));
    //        savePositions.Add(touchPosition);
    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            OnDraw?.Invoke();
    //            ARAnchor anchor = anchorManager.AddAnchor(new Pose(touchPosition, Quaternion.identity));

    //            if (anchor == null)
    //                Debug.LogError("Error creating reference point");
    //            else
    //            {
    //                anchors.Add(anchor);
    //                ARDebugManager.Instance.LogInfo($"Anchor created & total of {anchors.Count} anchor(s)");
    //            }

    //            fingerIdList.Add(touch.fingerId);

    //            //ARLine line = new ARLine(lineSettings);
    //            //Lines.Add(touch.fingerId, line);
    //            //line.AddNewLineRenderer(transform, anchor, touchPosition);
    //            //ARDebugManager.Instance.LogInfo($"Draw");

    //        }
    //        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
    //        {
    //            Lines[touch.fingerId].AddPoint(touchPosition);
    //        }
    //        else if (touch.phase == TouchPhase.Ended)
    //        {
    //            Lines.Remove(touch.fingerId);
    //        }
    //    }
    //}
}
