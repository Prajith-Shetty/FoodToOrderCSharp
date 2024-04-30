using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class Data
    {
        private List<Users> users = new List<Users> ();
        public List<Users> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
            }
        }

        private List<Restaurant> restaurants = new List<Restaurant>();
        public List<Restaurant> Restaurants
        {
            get { return restaurants; }
            set { restaurants = value; }
        }


        
        public Data()
        {
            Users.Add(new Users(101, "Prajith", "Shetty", "admin", "prajith123@gmail.com", "Prajith@12"));
            Users.Add (new Users (121,"Ram","Poojary","customer","ram12@gmail.com","ram@12"));
            Users.Add(new Users(122, "Rahul", "Bhat", "customer", "rahul12@gmail.com", "rahul@12"));
            Users.Add(new Users(123, "Santhosh", "Amin", "customer", "santh12@gmail.com", "sann@12"));
            Users.Add(new Users(124, "Kevin", "Lewis", "customer", "kevin12@gmail.com", "kevin@12"));
            Users.Add(new Users(125, "Sam", "George", "customer", "sam12@gmail.com", "sam@12"));

            //Restaurants.Add(new Restaurant(201, "Samruddhi", true, 101));
            //Restaurants.Add(new Restaurant(202, "KFC", true, 101));
            //Restaurants.Add(new Restaurant(203, "McDonalds", true, 101));
            //Restaurants.Add(new Restaurant(204, "Chaithanya", true, 101));
            //Restaurants.Add(new Restaurant(205, "Tulip", true, 101));


            //Restaurants[0].Dishes.Add(new Dish(501, "Dosa", true, 50, 201));
            //Restaurants[0].Dishes.Add(new Dish(502, "Plain Rice", true, 70, 201));
            //Restaurants[0].Dishes.Add(new Dish(503, "Mutton Rice Combo", true, 270, 201));
            //Restaurants[0].Dishes.Add(new Dish(504, "Chicken Roast", true, 350, 201));
            //Restaurants[0].Dishes.Add(new Dish(505, "Prawns Curry", true, 150, 201));

            //Restaurants[1].Dishes.Add(new Dish(601, "Burger", true, 70, 202));
            //Restaurants[1].Dishes.Add(new Dish(602, "Pizza", true, 200, 202));
            //Restaurants[1].Dishes.Add(new Dish(603, "Crispy Chicken", true, 250, 202));
            //Restaurants[1].Dishes.Add(new Dish(604, "Chicken Wings", true, 179, 202));
            //Restaurants[1].Dishes.Add(new Dish(605, "Special Combo", true, 350, 202));

            //Restaurants[2].Dishes.Add(new Dish(701, "McAloo Tikki Burger", true, 118, 203));
            //Restaurants[2].Dishes.Add(new Dish(702, "Masala McEgg Burger", true, 121, 203));
            //Restaurants[2].Dishes.Add(new Dish(703, "Chicken Kebab Burger", true, 179, 203));
            //Restaurants[2].Dishes.Add(new Dish(704, "McFlurry Oreo ", true, 200, 203));
            //Restaurants[2].Dishes.Add(new Dish(705, "Fries", true, 120, 203));

            //Restaurants[3].Dishes.Add(new Dish(801, "Chicken Roast", true, 230, 204));
            //Restaurants[3].Dishes.Add(new Dish(802, "Mutton Pepper Fry", true, 250, 204));
            //Restaurants[3].Dishes.Add(new Dish(803, "Prawn Fry", true, 150, 204));
            //Restaurants[3].Dishes.Add(new Dish(804, "Crab Curry", true, 170, 204));
            //Restaurants[3].Dishes.Add(new Dish(805, "Chicken Biriyani", true, 240, 204));

            //Restaurants[4].Dishes.Add(new Dish(901, "Chicken Biriyani", true, 180, 205));
            //Restaurants[4].Dishes.Add(new Dish(902, "Chicken Tandoori", true, 118, 205));
            //Restaurants[4].Dishes.Add(new Dish(903, "Prawn Curry", true, 150, 205));
            //Restaurants[4].Dishes.Add(new Dish(904, "Kadai Chicken", true, 170, 205));
            //Restaurants[4].Dishes.Add(new Dish(905, "Kadai Paneer", true, 150, 205));
        }

        
    }
}
