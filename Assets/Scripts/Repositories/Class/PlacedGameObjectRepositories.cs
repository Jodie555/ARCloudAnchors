using Assets.Scripts.DataObjects.Abstraction;
using Assets.Scripts.General.Abstraction;
using Assets.Scripts.Reporistories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Repositories.Class
{
    public class PlacedGameObjectRepositories : IPlacedGameObjectRepositories
    {
        public PlacedGameObjectRepositories() { }

        public void Add(IPlacedGameObject placedGameObject)
        {
            throw new NotImplementedException();
        }

        public IRoom AddToRoom(IRoom room, IPlacedGameObject placedGameObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(int placedGameObjectID)
        {
            throw new NotImplementedException();
        }

        public ISimpleResultWithPayload<IPlacedGameObject> Get(int placedGameObjectID)
        {
            throw new NotImplementedException();
        }

        public List<IPlacedGameObject> GetAllByRoomID(int roomID)
        {
            throw new NotImplementedException();
        }

        public void Update(IPlacedGameObject placedGameObject)
        {
            throw new NotImplementedException();
        }
    }
}
