using Assets.Scripts.DataObjects.Abstraction;
using Assets.Scripts.General.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Reporistories.Abstraction
{
    public interface IPlacedGameObjectRepositories
    {
        List<IPlacedGameObject> GetAllByRoomID(int roomID);
        ISimpleResultWithPayload<IPlacedGameObject> Get(int placedGameObjectID);
        void Add(IPlacedGameObject placedGameObject);

        void Update(IPlacedGameObject placedGameObject);

        void Delete(int placedGameObjectID);

        IRoom AddToRoom(IRoom room, IPlacedGameObject placedGameObject);
    }
}
