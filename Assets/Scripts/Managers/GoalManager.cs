using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{

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

    // Start is called before the first frame update
    void Start()
    {
        
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
}
