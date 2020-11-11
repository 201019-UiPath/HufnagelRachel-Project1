using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    public interface IManagerRepo
    {
        void AddManager (Manager manager);
        void UpdateManager (Manager manager);
        Manager GetManagerByManId (int manId);
        Manager GetManagerByEmail(string email);
        Manager GetManagerByLocationId(int locID);
        List <Manager> GetAllManagers();
        void DeleteManager (Manager manager);

        void SaveChanges();
    }
} 