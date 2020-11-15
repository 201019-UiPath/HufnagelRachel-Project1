using System.Collections.Generic;
using lacrosseDB.Models;
using lacrosseDB.Repos;

namespace lacrosseLib
{
    public class lineItemServices : IlineItemServices
    {
        private ILineItemRepo repo;

        public lineItemServices(ILineItemRepo repo)
        {
            this.repo = repo;
        }

        public void AddLineItem(lineItem lineItem)
        {
            repo.AddLineItem(lineItem);
        }
        public void UpdateLineItem(lineItem lineItem)
        {
            repo.UpdateLineItem(lineItem);
        }
        public lineItem GetLineItemByOrderId(int orderId)
        {
            lineItem lineItem = repo.GetLineItemByOrderId(orderId);
            return lineItem;
        }
        public List<lineItem> GetAllLineItemsByOrderId(int orderId)
        {
            List<lineItem> lineItems = repo.GetAllLineItemsByOrderId(orderId);
            return lineItems;
        }
        public void DeleteLineItem(lineItem lineItem)
        {
            repo.DeleteLineItem(lineItem);
        }
    }
}