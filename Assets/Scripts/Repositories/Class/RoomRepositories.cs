using Assets.Scripts.DataObjects.Abstraction;
using Assets.Scripts.Repositories.Abstraction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Repositories.Class
{
    public class RoomRepositories : IRoomRepositories
    {

        FirebaseInit firebaseInit;
        public RoomRepositories() {
            FirebaseInit firebaseInit = new FirebaseInit();

        }

        public void Add(IRoom room)
        {
            throw new NotImplementedException();
        }

        public void Delete(int roomID)
        {
            throw new NotImplementedException();
        }

        public async Task<IRoom> Get(int roomID)
        {
            string testObject1 = await firebaseInit.GetObject("testinWayID/roomID1");
            ARDebugManager.Instance.LogInfo($"testoneObject {testObject1}");

            // get list of object
            string listObjects = await firebaseInit.GetObject("testinWayID", "roomID1");
            try
            {
                //List<PlacedGameObject> listpPlacedObject = JsonConvert.DeserializeObject<List<PlacedGameObject>>(listObjects);
                //ARDebugManager.Instance.LogInfo($"list placedObject {listpPlacedObject[0].position}");
                Assets.Scripts.DataObjects.Object.Room listPlacedObject = JsonConvert.DeserializeObject<Assets.Scripts.DataObjects.Object.Room>(listObjects);
                ARDebugManager.Instance.LogInfo($"list placedObject {listPlacedObject.placedGameObjects["key_0"].position}");

            }
            catch
            (System.Exception e)
            {
                ARDebugManager.Instance.LogInfo($"Error {e.Message}");
            }

            return null;
        }

        public List<IRoom> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<IRoom> GetAllByUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public void Update(IRoom room)
        {
            throw new NotImplementedException();
        }
    }
}
