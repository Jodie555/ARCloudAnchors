using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
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
        arCloudAnchorManager.SavePlacedObjectList();
    }

    public void changePlacedPrefabButton()
    {
        arPlacementManager.changePlacedPrefab("TestingAnchor");
    }

    public void chooseCharacterPrefabButton()
    {
        arPlacementManager.changePlacedPrefab("Character");
    }

    public void reDrawButton()
    {
        arDrawManager.TestDraw();
    }

    public void getAnchorListButton()
    {
        arCloudAnchorManager.getListOfAnchors();
    }

    public void changeSceneButton()
    {
        sceneEventManager.ChangeScene();
    }

    public void ToggleDrawButton()
    {
        arDrawManager.ToggleDraw();
    }

    public void TogglePlacementButton()
    {
        arPlacementManager.TogglePlacement();
    }

    public void ChangeMainMenuSceneButton()
    {
        sceneEventManager.MainMenuScene();
    }

    public void ChangeStartSceneButton()
    {
        sceneEventManager.StartScene();
    }
}
