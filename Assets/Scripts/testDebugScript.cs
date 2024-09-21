using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDebugScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ARDebugManager.Instance.LogInfo("Activate AR Cloud Anchor Experience");

    }
}
