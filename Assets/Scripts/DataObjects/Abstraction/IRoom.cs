using Assets.Scripts.DataObjects.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataObjects.Abstraction
{
    public interface IRoom
    {
        string roomID { get; set; }
        Dictionary<string, IPlacedGameObject> placedGameObjects { get; set; }
        Dictionary<string, bool> members_UserID { get; set; }
        string owner_UserID { get; set; }
        DateTime createdAt { get; set; }
        string createdBy { get; set; }
        DateTime updatedAt { get; set; }
        string updatedBy { get; set; }

    }
}
