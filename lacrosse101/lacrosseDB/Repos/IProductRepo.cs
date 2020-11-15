using lacrosseDB.Models;
using System.Collections.Generic;

namespace lacrosseDB.Repos
{
    public interface IProductRepo
    {
        void AddStick(Sticks stick);
        void DeleteStick(Sticks stick);
        void UpdateStick(Sticks stick);
        List<Sticks> GetAllSticks();
        Sticks GetProductByStickId(int Id);

        // instead of using linq update method 
        void SaveChanges();
    }
}