using RESToran.Models;
using System.Collections.Generic;

namespace RESToran.DataAccess
{
    interface IRestaurantProvider
    {
        void AddRestaurantRecord(Restaurant restaurant);
        void UpdateRestaurantRecord(Restaurant restaurant);
        void DeletePatientRecord(string id);
        Restaurant GetRestaurantSingleRecord(string id);
        List<Restaurant> GetRestaurantRecords();
    }
}
