using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class Dish
    {

        public event PriceDroppedHandler PriceDropped;
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id= value;
            }
        }

        private string dishName;

        public string DishName
        {
            get { return dishName; }
            set { dishName = value; }
        }

        private bool available;

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set {
                if (value < price)
                {
                    PriceDropped();
                }
                price = value; 
            
            }
        }

        private int restaurantId;

        public int RestaurantId
        {
            get { return restaurantId; }
            set { restaurantId = value; }
        }

        public Dish()
        {
        }

        public Dish(int id, string dishName, bool available, double price, int restaurantId)
        {
            Id = id;
            DishName = dishName;
            Available = available;
            Price = price;
            RestaurantId = restaurantId;
        }

        public override string ToString()
        {
            return dishName + "   -   Rs. "+price;
        }

        public delegate void PriceDroppedHandler();
    }
}
