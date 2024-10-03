using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class test : MonoBehaviour
{

    private ARDrawManager arDrawManager = null;


    [SerializeField]
    [Tooltip("The slider for activating plane debug visuals.")]
    DebugSlider m_ArDrawSlider;

    /// <summary>
    /// The slider for activating plane debug visuals.
    /// </summary>
    public DebugSlider arDrawSlider
    {
        get => m_ArDrawSlider;
        set => m_ArDrawSlider = value;
    }


    // Start is called before the first frame update
    void Start()
    {

        try
        {
            arDrawManager = GetComponent<ARDrawManager>();
            arDrawManager.ToggleDraw();
        }
        catch (System.Exception e)
        {
            ARDebugManager.Instance.LogInfo($"Error {e.Message}");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //prefabManager.saveGameObjectsPosition();
    }

    public void ShowHideDebugPlane()
    {
        try
        {
            arDrawManager.ToggleDraw();
        }
        catch (System.Exception e)
        {
            ARDebugManager.Instance.LogInfo($"Error {e.Message}");
        }


        if (m_ArDrawSlider.value == 1)
        {
            m_ArDrawSlider.value = 0;

        }
        else
        {
            m_ArDrawSlider.value = 1;
        }
    }
}
