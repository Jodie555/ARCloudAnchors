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
        ARDebugManager.Instance.LogInfo($"Finished");

        //CreateNewUser();


        //GetBackInfo();

    }

    //public void CreateNewUser()
    //{
    //    reference.Child("users").Child(userId).SetValueAsync("John Doe");
    //    Debug.Log("New User Created");
    //}

    //public void GetBackInfo()
    //{
    //    reference.Child("users")
    //     .Child(userId)
    //     .GetValueAsync().ContinueWithOnMainThread(task => {
    //         if (task.IsFaulted)
    //         {
    //             Debug.Log(task.Exception.Message);
    //             ARDebugManager.Instance.LogInfo($"Failed");
    //         }
    //         else if (task.IsCompleted)
    //         {
    //             ARDebugManager.Instance.LogInfo($"Finished{task.Result}");
    //             DataSnapshot snapshot = task.Result;
    //             Debug.Log("Name=" + snapshot.Value);
    //             ARDebugManager.Instance.LogInfo($"Finished{snapshot.Value}");
    //         }
    //     });

    //}

    public void uploadString(string key,string value)
    {
        reference.Child(key).SetValueAsync(value);

    }


    //public void uploadListData(string key, string itemName, List<object> values)
    //{
    //    ARDebugManager.Instance.LogInfo($"uploadListData {values}");

    //    int i = 0;
    //    foreach (object val in values)
    //    {
    //        ARDebugManager.Instance.LogInfo($"val {val}");

    //        ARDebugManager.Instance.LogInfo($"Test uploadListData {val.ToString()}");
    //        ARDebugManager.Instance.LogInfo($"item Name {itemName + i.ToString()}");

    //        reference.Child(key).Child(itemName + i.ToString()).SetValueAsync(val.ToString());
    //        i++;
    //    }

    //}

    //public void uploadObject(string key, object value)
    //{
    //    reference.Child(key).SetValueAsync(value);
    //}

    public void uploadObject(string key, string value)
    {
        reference.Child(key).SetRawJsonValueAsync(value);
    }

    public void uploadObject(string key,string id, string value)
    {
        reference.Child(key).Child(id).SetRawJsonValueAsync(value);
    }


    //public async Task<string> getData(string key )
    //{
    //    string targetValue = null;
    //    await reference.Child(key)
    //     .GetValueAsync().ContinueWithOnMainThread(task => {
    //         if (task.IsFaulted)
    //         {
    //             Debug.Log(task.Exception.Message);
    //             ARDebugManager.Instance.LogInfo($"Failed");
    //         }
    //         else if (task.IsCompleted)
    //         {
    //             ARDebugManager.Instance.LogInfo($"Finished{task.Result}");
    //             DataSnapshot snapshot = task.Result;
    //             targetValue = snapshot.Value.ToString();
    //             Debug.Log("Name=" + snapshot.Value);
    //             ARDebugManager.Instance.LogInfo($"Finished{targetValue}");
    //         }
    //     });
    //    return targetValue;

    //}



    //public async Task<T>  GetDictTest<T>(string key) where T : class
    //{
    //    T targetValue = null;
    //    await reference.Child(key)
    //     .GetValueAsync().ContinueWithOnMainThread(task => {
    //         if (task.IsFaulted)
    //         {
    //             Debug.Log(task.Exception.Message);
    //             ARDebugManager.Instance.LogInfo($"Failed");
    //         }
    //         else if (task.IsCompleted)
    //         {
    //             ARDebugManager.Instance.LogInfo($"Finished{task.Result}");
    //             DataSnapshot snapshot = task.Result;
    //             targetValue = snapshot.Value as T;
    //             Debug.Log("Name=" + snapshot.Value);


    //         }
    //     });
    //    return targetValue;

    //}


    public async Task<string> GetObject(string key)
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
                 targetValue = snapshot.GetRawJsonValue();
                 Debug.Log("Name=" + snapshot.Value);


             }
         });
        return targetValue;

    }


    public async Task<string> GetObject(string key,string id)
    {
        string targetValue = null;
        await reference.Child(key).Child(id)
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
                 targetValue = snapshot.GetRawJsonValue();
                 Debug.Log("Name=" + snapshot.Value);


             }
         });
        return targetValue;

    }


    public async Task<string> GetObject(string key, string id, string variable)
    {
        string targetValue = null;
        await reference.Child(key).Child(id).Child(variable)
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
                 targetValue = snapshot.GetRawJsonValue();
                 Debug.Log("Name=" + snapshot.Value);


             }
         });
        return targetValue;

    }

}


