using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneUIManager : MonoBehaviour
{

    private ARCloudAnchorManager arCloudAnchorManager = null;
    private ARPlacementManager arPlacementManager = null;
    private ARDrawManager arDrawManager = null;
    private SceneEventManager sceneEventManager = null;
    // Start is called before the first frame update
    void Start()
    {
        arCloudAnchorManager = GetComponent<ARCloudAnchorManager>();
        arPlacementManager = GetComponent<ARPlacementManager>();
        arDrawManager = GetComponent<ARDrawManager>();
        sceneEventManager = GetComponent<SceneEventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hostButton()
    {
        arCloudAnchorManager.HostAnchor();
    }

    public void resolveButton()
    {
        arCloudAnchorManager.resolveAnchor();
    }

    public void saveCloudAnchorIDButton()
    {
        arCloudAnchorManager.SaveCloudAnchorID();
    }

    public void changePlacedPrefabButton()
    {
        arPlacementManager.changePlacedPrefab();
    }

    public void reDrawButton()
    {
        arDrawManager.TestDraw();
    }

    public void changeSceneButton()
    {
        sceneEventManager.ChangeScene();
    }

}
