using Assets.Scripts.DataObjects.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Repositories.Abstraction
{
    public interface IRoomRepositories
    {
        List<IRoom> GetAllByUserID(int userID);
        Task<IRoom> Get(int roomID);
        void Add(IRoom room);

        void Update(IRoom room);

        void Delete(int roomID);
    }
}
