using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacedGameObjectClass;

public class AnchorListManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<PlacedGameObject> placedGameObjects = new List<PlacedGameObject>();


    public void AddPlacedGameObject(PlacedGameObject placedGameObject)
    {
        placedGameObjects.Add(placedGameObject);
    }

    public void RemovePlacedGameObject(PlacedGameObject placedGameObject)
    {
        placedGameObjects.Remove(placedGameObject);
    }
}
