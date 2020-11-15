using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public interface IlineItemServices
    {
        void AddLineItem(lineItem lineItem);
        void DeleteLineItem(lineItem lineItem);
        List<lineItem> GetAllLineItemsByOrderId(int orderId);
        lineItem GetLineItemByOrderId(int orderId);
        void UpdateLineItem(lineItem lineItem);
    }
}