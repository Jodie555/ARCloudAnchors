using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GoalManager : MonoBehaviour
{

    private ARDrawManager arDrawManager = null;


    [Tooltip("The greeting prompt Game Object to show when onboarding begins.")]
    [SerializeField]
    GameObject m_GreetingPrompt;

    /// <summary>
    /// The greeting prompt Game Object to show when onboarding begins.
    /// </summary>
    public GameObject greetingPrompt
    {
        get => m_GreetingPrompt;
        set => m_GreetingPrompt = value;
    }


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
        arDrawManager = GetComponent<ARDrawManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteGoal()
    {
        m_GreetingPrompt.SetActive(false);
        ARDebugManager.Instance.LogInfo($"testoneObject");

    }

    public void ShowHideDebugPlane()
    {
        try {
            arDrawManager.ToggleDraw();
        }
        catch(System.Exception e)
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
