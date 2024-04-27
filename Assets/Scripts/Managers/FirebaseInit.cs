using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using Firebase.Database;

public class FirebaseInit : MonoBehaviour
{
    string userId;
    DatabaseReference reference;

    void Start()
    {
        ARDebugManager.Instance.LogInfo($"testing");
        userId = SystemInfo.deviceUniqueIdentifier;
        ARDebugManager.Instance.LogInfo($"connecting{userId}");

        ARDebugManager.Instance.LogInfo($"connecting{FirebaseDatabase.DefaultInstance}");
        reference = FirebaseDatabase.DefaultInstance.RootReference;


        CreateNewUser();
        ARDebugManager.Instance.LogInfo($"Finished");

    }

    public void CreateNewUser()
    {
        reference.Child("users").Child(userId).SetValueAsync("John Doe");
        Debug.Log("New User Created");
    }
}
