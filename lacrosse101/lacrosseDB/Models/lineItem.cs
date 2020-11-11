namespace lacrosseDB.Models
{
    public class lineItem
    {
        public int Id {get; set;}
        public int orderId {get; set;}
        public Orders order {get; set;}
        public int stickId {get; set;}
        public Sticks stick {get; set;}
        public double price {get; set;}
        public int quantity {get; set;}

    }
}