using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseDB.Models;
using System.Collections.Generic;


namespace lacrosseLib
{
    public class ProductServices
    {
        private IProductRepo prodRepo;

        public ProductServices(IProductRepo prodRepo)
        {
            this.prodRepo = prodRepo;
        }

        public void AddStick(Sticks stick)
        {
            prodRepo.AddStick(stick);
        }

        public void DeleteStick(Sticks stick)
        {
            prodRepo.DeleteStick(stick);
        }


        public Sticks GetProductByStickId(int stickId)
        {
            Sticks stick = prodRepo.GetProductByStickId(stickId);
            return stick;
        }

    }
}