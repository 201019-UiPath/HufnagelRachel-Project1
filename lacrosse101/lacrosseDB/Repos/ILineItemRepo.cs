using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    public interface ILineItemRepo
    {
        void AddLineItem(lineItem lineItem);
        void UpdateLineItem(lineItem lineItem);
        lineItem GetLineItemByOrderId(int orderId);
        List<lineItem> GetAllLineItemsByOrderId(int orderId);
        void DeleteLineItem(lineItem lineItem);
    }
}