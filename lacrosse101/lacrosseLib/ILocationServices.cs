using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public interface ILocationServices
    {
        void AddLocation(Locations location);
        void DeleteLocation(Locations location);
        List<Locations> GetAllLocations();
        Locations GetLocationByLocationId(int locationId);
        void UpdateLocation(Locations location);
    }
}