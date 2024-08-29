using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataObjects.Abstraction
{
    public interface IPlacedGameObject
    {
        string placedGameObjectID { get; set; }
        float positionX { get; set; }
        float positionY { get; set; }
        float positionZ { get; set; }
        float rotationW { get; set; }
        float rotationX { get; set; }
        float rotationY { get; set; }
        float rotationZ { get; set; }
        string prefabName { get; set; }
        string tag { get; set; }
        UnityEngine.GameObject gameObject { get; set; }
        string owner_UserID { get; set; }
        Dictionary<string, bool> members_UserID { get; set; }
    }
}
