using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class Restaurant
    {
        private int id;
        public int Id { 
            get { return id; } 
            set { id = value; }
        }

        private string restaurantName;
        public string RestaurantName
        {
            get { return restaurantName; }
            set { restaurantName = value; }
        }
        private bool open;

        public bool Open
        {
            get { return open; }
            set { open = value; }
        }


        private int userId;
        public int UserId { 
            get { return userId; }
            set { userId = value; } 
        }

        private List<Dish> dishes = new List<Dish>();
        public List<Dish> Dishes
        {
            get
            {
                return dishes;
            }
            set
            {
                dishes = value;
            }
        }

        public Restaurant() { }
        public Restaurant(int id,string restaurantName,bool open, int userId)
        {
            Id = id;
            RestaurantName=restaurantName;
            Open = open;
            UserId=userId;
        }

        public Restaurant(int id, string restaurantName)
        {
            Id = id;
            RestaurantName = restaurantName;
        }

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
        }

        public override string ToString()
        {
            return RestaurantName;
        }

    }

   
}
