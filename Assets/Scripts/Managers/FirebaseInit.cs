using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using Firebase.Database;
using System.Threading.Tasks;

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

        GetBackInfo();

    }

    public void CreateNewUser()
    {
        reference.Child("users").Child(userId).SetValueAsync("John Doe");
        Debug.Log("New User Created");
    }

    public void GetBackInfo()
    {
        reference.Child("users")
         .Child(userId)
         .GetValueAsync().ContinueWithOnMainThread(task => {
             if (task.IsFaulted)
             {
                 Debug.Log(task.Exception.Message);
                 ARDebugManager.Instance.LogInfo($"Failed");
             }
             else if (task.IsCompleted)
             {
                 ARDebugManager.Instance.LogInfo($"Finished{task.Result}");
                 DataSnapshot snapshot = task.Result;
                 Debug.Log("Name=" + snapshot.Value);
                 ARDebugManager.Instance.LogInfo($"Finished{snapshot.Value}");
             }
         });

    }

    public void uploadData(string key,string value)
    {
        reference.Child(key).SetValueAsync(value);

    }

    public async Task<string> getData(string key )
    {
        string targetValue = null;
        await reference.Child(key)
         .GetValueAsync().ContinueWithOnMainThread(task => {
             if (task.IsFaulted)
             {
                 Debug.Log(task.Exception.Message);
                 ARDebugManager.Instance.LogInfo($"Failed");
             }
             else if (task.IsCompleted)
             {
                 ARDebugManager.Instance.LogInfo($"Finished{task.Result}");
                 DataSnapshot snapshot = task.Result;
                 targetValue = snapshot.Value.ToString();
                 Debug.Log("Name=" + snapshot.Value);
                 ARDebugManager.Instance.LogInfo($"Finished{targetValue}");
             }
         });
        return targetValue;

    }

}
