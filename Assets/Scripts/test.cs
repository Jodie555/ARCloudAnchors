using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private PrefabManager prefabManager = null;
    // Start is called before the first frame update
    void Start()
    {
        prefabManager = GetComponent<PrefabManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //prefabManager.saveGameObjectsPosition();
    }
}
