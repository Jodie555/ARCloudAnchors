using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEventManager : MonoBehaviour
{
    [SerializeField]
    private string sceneName = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("NewScene");

    }

    public void BackToMainScene()
    {

        //SceneManager.LoadScene("NewScene");
        SceneManager.LoadScene("ARCloudAnchor");

    }

}
