using System.Collections.Generic;
using lacrosseDB.Models;


namespace lacrosseDB.Repos
{
    public interface ILocationRepo
    {
        void AddLocation(Locations locatio);
        void UpdateLocation(Locations location);
        Locations GetLocationByLocationId(int locationId);
        List<Locations> GetAllLocations();
        void DeleteLocation(Locations locations);

        void SaveChanges();
    }
}