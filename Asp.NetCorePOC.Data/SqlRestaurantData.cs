using System.Collections.Generic;
using System.Linq;
using Asp.NetCorePOC.Model;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCorePOC.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly POCDbContext db;

        public SqlRestaurantData(POCDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }
        /// <summary>
        /// All the changes are reconciled and committed to DB when this method is called
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            return db.SaveChanges(); // returns # of rows affected
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return db.Restaurants.Where(x => x.Name.StartsWith(name) || string.IsNullOrEmpty(name));
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant); // Attache tells EF to start tracking changes made on this object
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
