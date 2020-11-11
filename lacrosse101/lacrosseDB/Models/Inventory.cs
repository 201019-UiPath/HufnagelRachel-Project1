namespace lacrosseDB.Models
{
    /// <summary>
    /// The class inventory which acts as a join tables between location and products
    /// </summary>
    public class Inventory
    {

        public int Id { get; set; }

        public int stickId {get; set;}

        public Sticks stick {get; set;}

        public int LocationId { get; set; }

        public Locations location {get; set;}
        public int quantity {get; set;}

    }
}