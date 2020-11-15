using System.Collections.Generic;
using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public class LocationServices : ILocationServices
    {
        private ILocationRepo locRepo;

        public LocationServices(ILocationRepo locRepo)
        {
            this.locRepo = locRepo;
        }

        public void AddLocation(Locations location)
        {
            locRepo.AddLocation(location);
        }

        public void UpdateLocation(Locations location)
        {
            locRepo.UpdateLocation(location);
        }

        public Locations GetLocationByLocationId(int locationId)
        {
            Locations location = locRepo.GetLocationByLocationId(locationId);
            return location;
        }

        public List<Locations> GetAllLocations()
        {
            List<Locations> allLocations = locRepo.GetAllLocations();
            return allLocations;
        }

        public void DeleteLocation(Locations location)
        {
            locRepo.DeleteLocation(location);
        }
    }
}