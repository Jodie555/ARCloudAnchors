using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataObjects.Abstraction
{
    public interface IUser
    {
        string name { get; set; }
        string email { get; set; }
        string password { get; set; }
        string createdAt { get; set; }
        string updatedAt { get; set; }
    }
}
