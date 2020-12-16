using RESToran.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESToran.DataAccess
{
    public class RestaurantProvider : IRestaurantProvider
    {
        private readonly PostgreSqlContext _context;

        public RestaurantProvider(PostgreSqlContext context)
        {
            _context = context;
        }
        public void AddRestaurantRecord(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }

        public void DeletePatientRecord(string id)
        {
            long res_id = long.Parse(id);
            var entity = _context.Restaurants.FirstOrDefault(r => r.Id == res_id);
            _context.Restaurants.Remove(entity);
            _context.SaveChanges();
        }

        public List<Restaurant> GetRestaurantRecords()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetRestaurantSingleRecord(string id)
        {
            long res_id = long.Parse(id);
            return _context.Restaurants.FirstOrDefault(r => r.Id == res_id);
           
        }

        public void UpdateRestaurantRecord(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();
        }
    }
}
