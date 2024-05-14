using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsManager : MonoBehaviour
{
    [SerializeField]
    public GameObject placementObjectPrefab = null;

    [SerializeField]
    public GameObject characterPrefab = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getGameObjectByName(string name)
    {
        if (name == "TestingAnchor")
        {
            return placementObjectPrefab;
        }
        else if (name == "Character")
        {
            return characterPrefab;
        }
        else
        {
            return null;
        }
    }
}
