using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public interface IProductServices
    {
        void AddStick(Sticks stick);
        void DeleteStick(Sticks stick);
        List<Sticks> GetAllSticks();
        Sticks GetProductByStickId(int stickId);
        void UpdateStick(Sticks stick);
    }
}