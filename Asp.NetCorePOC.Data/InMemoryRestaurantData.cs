using Asp.NetCorePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp.NetCorePOC.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "India Palace", Location = "San Antonio", Cuisine = CuisineType.Indian},
                new Restaurant {Id = 2, Name = "Olive Garden", Location = "San Antonio", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 3, Name = "Chuy's", Location = "San Antonio", Cuisine = CuisineType.Mexican}
            };
        }
        //public IEnumerable<Restaurant> GetAll()
        //{
        //    return restaurants.OrderBy(x => x.Name);
        //}

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants
                .Where(x=> string.IsNullOrEmpty(name) || x.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x.Name);
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(x => x.Id) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = restaurants.FirstOrDefault(x => x.Id == Id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }
}
