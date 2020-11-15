using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseDB.Models;
using System.Collections.Generic;


namespace lacrosseLib
{
    public class ProductServices : IProductServices
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

        public void UpdateStick(Sticks stick)
        {
            prodRepo.UpdateStick(stick);
        }

        public List<Sticks> GetAllSticks()
        {
            List<Sticks> stick = prodRepo.GetAllSticks();
            return stick;
        }


        public Sticks GetProductByStickId(int stickId)
        {
            Sticks stick = prodRepo.GetProductByStickId(stickId);
            return stick;
        }

    }
}