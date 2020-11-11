using lacrosseDB.Models;
using System.Collections.Generic;

namespace lacrosseDB.Repos
{
    public interface IProductRepo
    {
        void AddStick(Sticks stick);
        void DeleteStick(Sticks stick);
        Sticks GetProductByStickId(int Id);

        // instead of using linq update method 
        void SaveChanges();
    }
}