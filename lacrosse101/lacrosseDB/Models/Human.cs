namespace lacrosseDB.Models
{
    /// <summary>
    /// The abstract class Human which help implement the classes customer and manager
    /// </summary>
    public abstract class Human
    {
        /// <summary>
        /// Property of the human class
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Property of the human class
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }

        /// <summary>
        /// Property of the human class
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }

        /// <summary>
        /// Property of the human class
        /// </summary>
        /// <value></value>
        public string email {get; set;}
        
        /// <summary>
        /// Property of the human class
        /// </summary>
        /// <value></value>
        public int LocationId { get; set; }


    }
}