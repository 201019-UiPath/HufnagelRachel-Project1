using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public interface IManagerServices
    {
        void AddManager(Manager manager);
        void DeleteManager(Manager manager);
        List<Manager> GetAllManagers();
        Manager GetManagerByEmail(string email);
        Manager GetManagerByLocationId(int locID);
        Manager GetManagerByManId(int manId);
        void UpdateManager(Manager manager);
    }
}