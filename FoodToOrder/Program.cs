// See https://aka.ms/new-console-template for more information
using FoodToOrderLibrary;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Security;

Console.WriteLine("              ___________   ");
Console.WriteLine("              FoodToOrder    ");
Console.WriteLine("              ***********   ");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("      Welcome to FoodToOrder App");
Console.WriteLine();

var role = " ";
var fName = " ";
var lName = " ";
bool verified = false;

Data data = new();

Authenticate:
Console.WriteLine("Please enter your Email and Password");
Console.Write("Email : ");
var email = Console.ReadLine();
Console.Write("Password : ");
var password = Console.ReadLine();
Console.WriteLine();
foreach (Users user in data.Users)
{
    if(user.Email == email && user.Password == password)
    {
        role = user.Role;
        fName = user.FirstName;
        lName = user.LastName;
        verified = true;
        Console.WriteLine("Login success!!!");
        Console.WriteLine();
    }
}

if (!verified)
{
    Console.WriteLine("Please check your email and password and try again...");
    goto Authenticate;
}

List<Restaurant> Restaurants = new List<Restaurant>();
using (StreamReader r = new StreamReader("Restaurants.json"))
{
    string json = r.ReadToEnd();
    Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);

}

if (role == "admin")
{
    Console.WriteLine($"Welcome {fName} to FoodToOrder Admin Panel!");
    Console.WriteLine("Restaurants Available:");

    
    // LINQ query to project both RestaurantId and RestaurantName
    List<Restaurant> queryToGetAllRestNamesAndIds = Restaurants.Select(restaurant => new Restaurant(restaurant.Id,restaurant.RestaurantName)).ToList();

    // Action delegate to display both restId and restName
    Action<List<Restaurant>> action = (restList) =>
    {
        foreach (var rest in restList)
        {
            Console.WriteLine($"Id: {rest.Id}, Name: {rest.RestaurantName}");
        }
    };
    

    action(queryToGetAllRestNamesAndIds);

    
    Console.WriteLine();

    AdminChoice:
    Console.WriteLine("What action you want to perform");
    Console.WriteLine("1. View a Restaurant");
    Console.WriteLine("2. Add new Restaurant");
    Console.WriteLine("3. Edit/Update a Restaurant");
    Console.WriteLine("4. Delete a Restaurant");
    Console.WriteLine("5. Exit");

    int adminChoice = int.Parse(Console.ReadLine());

    

    switch (adminChoice)
    {
        case 1: ViewRestaurant();
            break;
        case 2: AddRestaurant();
            break;
        case 3: UpdateRestaurant();
            break;
        case 4: DeleteRestaurant();
            break;
        case 5: Environment.Exit(0);
            break;
        default: 
            Console.WriteLine("Please provide a right choice..");
            goto AdminChoice;
    }

    Console.WriteLine("Do you want to perform any action? (Type 'Y' for Yes and any other key to exit)");
    string adminOp = Console.ReadLine();
    if(adminOp=="Y" || adminOp == "y")
    {
        goto AdminChoice;
    }
    else
    {
        Console.WriteLine("Thank You for visiting!!!");
    }

    
    string json2 = JsonConvert.SerializeObject(Restaurants, Formatting.Indented);

    
    using (StreamWriter writer = new StreamWriter("Restaurants.json"))
    {
        writer.Write(json2);
    }
}
else if(role == "customer")
{
    Console.WriteLine($"Welcome {fName} to FoodToOrder App!");
    Console.WriteLine();

RestaurantsPanel:
    Console.WriteLine("Please choose a restaurant for you to order: ");

    
    foreach(Restaurant rest in Restaurants)
    {
        //checks if the restaurant is open
        if (rest.Open)
        {
            Console.WriteLine(rest.Id + " - " + rest);           
        }      
    }
    Console.WriteLine();
    Console.WriteLine("Enter Restaurant Id: ");
    int restId = int.Parse(Console.ReadLine());
    Console.WriteLine();
    var restaurant = Restaurants.Where(rest => rest.Id == restId).FirstOrDefault();
   //Console.WriteLine(restaurant.RestaurantName);
    int cartDetailId = 301;
    Cart cart = new Cart();


//cart.CalculateAmount += UpdateAmountInCart;

//void UpdateAmountInCart()
//{
//    Console.WriteLine("Hello");
//    int Qty = cart.CartDetails[cart.CartDetails.Count-1].Quantity;
//    int DishId = cart.CartDetails[cart.CartDetails.Count - 1].DishId;

//    //LINQ
//    double queryToGetDishPrice = Restaurants[choice - 1].Dishes.Where(dish => dish.Id == DishId).Select(dish=>dish.Price).FirstOrDefault() ;

//    cart.Amount = queryToGetDishPrice * Qty;
//    Console.WriteLine(cart.Amount);
//}

SelectDishes:
    Console.WriteLine("Please select dishes of your choice");

    var dishes = restaurant.Dishes;
    foreach(Dish dish in dishes)
    {
        if (dish.Available==true)
        {
            Console.WriteLine(dish.Id + " - " + dish);
        }
        
    }

    Console.WriteLine("\n(Press -1 to go back)");
    Console.WriteLine();
    Console.WriteLine("Enter Dish Id of the dish you need: ");
    int dishId = int.Parse(Console.ReadLine());
    if(dishId == -1)
    {
        goto RestaurantsPanel;
    }
    Console.WriteLine("\nSelect the Quantity: ");
    int qty = int.Parse(Console.ReadLine());

    Console.WriteLine();
    Console.WriteLine("Adding your item to cart...");
    Console.WriteLine();


    cart.CartDetails.Add(new CartDetail(cartDetailId++, dishId,qty));

    //int Qty = cart.CartDetails[cart.CartDetails.Count - 1].Quantity;
    //int DishId = cart.CartDetails[cart.CartDetails.Count - 1].DishId;

    //LINQ
    double queryToGetDishPrice = restaurant.Dishes.Where(dish => dish.Id == dishId).Select(dish => dish.Price).FirstOrDefault();

    cart.Amount += queryToGetDishPrice * qty;

    Console.WriteLine("Do you want to add more dishes to your cart? (Click 'Y' for Yes)");
    

    if (Console.ReadLine() == "Y")
    {
        goto SelectDishes;
    }
    Console.WriteLine();

    Console.WriteLine("Generating Bill...");
    Console.WriteLine();
    Console.WriteLine("___________________________________________________________");
    Console.WriteLine();
    Console.WriteLine("                         FoodToOrder                       ");
    Console.WriteLine("___________________________________________________________");
    Console.WriteLine();
    Console.WriteLine("                         Total Bill                        ");
    Console.WriteLine("___________________________________________________________");
    Console.WriteLine($"Restaurant Name: {restaurant.RestaurantName}");
    Console.WriteLine("");
    Console.WriteLine("Sl.No.   |    Product Name   | Qty |  Price  | Amount");
    int i = 1;
    foreach(CartDetail cd in cart.CartDetails)
    {
        int billDishId = cd.DishId;
        int billQty = cd.Quantity;
        double queryToGetDishPriceBill = restaurant.Dishes.Where(dish => dish.Id == billDishId).Select(dish => dish.Price).FirstOrDefault();
        string? dishNameBill = restaurant.Dishes.Where(dish => dish.Id == billDishId).Select(dish => dish.DishName).FirstOrDefault();
        Console.WriteLine($"{i++}  | {dishNameBill} | {billQty} | {queryToGetDishPriceBill} | {billQty * queryToGetDishPriceBill} ");
    }
    Console.WriteLine("___________________________________________________________");
    Console.WriteLine($"                               Total Bill : {cart.Amount}");


}

void ViewRestaurant()
{
    Console.WriteLine("Enter Id and Name of the Restaurant which you want to view");
    Console.WriteLine("Enter Id:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.WriteLine("Enter Name:");
    string restName = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("Restaurant Details:");

    if (id!=0 && restName!=null)
    {
        var rest = Restaurants.Where(rest => rest.Id == id && rest.RestaurantName == restName).FirstOrDefault();
        if (rest != null)
        {
            Console.WriteLine($"Restaurant Name : {rest.RestaurantName}");
            Console.WriteLine($"Restaurant Id : {rest.Id}");
            Console.WriteLine($"Open : {rest.Open}");
            Console.WriteLine($"UserId : {rest.UserId}");
            Console.WriteLine();
            Console.WriteLine("Dishes : ");
            foreach(Dish dish in  rest.Dishes)
            {
                Console.WriteLine($"Dish Id : {dish.Id}");
                Console.WriteLine($"Dish Name : {dish.DishName}");
                Console.WriteLine($"Available : {dish.Available}");
                Console.WriteLine($"Price : {dish.Price}");
                Console.WriteLine();
            }
        }
    }
    else
    {
        Console.WriteLine("Id or RestaurantName cannot be null");
        return;
    }
    
    
   

}

void AddRestaurant()
{
    Console.WriteLine("Enter Id and Name of the Restaurant");
    Console.WriteLine("Enter Id:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.WriteLine("Enter Restaurant Name:");
    string restName = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("Is the Restaurant open/closed? Type 'O' for open and 'C' for closed");
    string openOrClosed = Console.ReadLine();
    Console.WriteLine();
    bool open;
    if(openOrClosed=="O" || openOrClosed == "o")
    {
        open = true;
    }
    else
    {
        open = false;
    }
    Console.WriteLine("Enter UserId:");
    int userId = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Restaurant rest = new Restaurant(id, restName, open, userId);

    Console.WriteLine("Do you want to add dishes to this new restaurant? (Type 'Y' for 'Yes')");
    string s = Console.ReadLine();
    Console.WriteLine();
    if (s =="Y" || s == "y")
    {
        bool wantToAddDish = true;
        while (wantToAddDish)
        {
            wantToAddDish = false;
            
            Console.WriteLine("Enter Id of the Dish:");
            int dishId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Enter Dish Name:");
            string dishName = Console.ReadLine();
            Console.WriteLine();
                    
            Console.WriteLine("Is the Dish Available? Type 'A' for Available");
            string avlOrNot = Console.ReadLine();
            Console.WriteLine();
            bool avl;
            if (avlOrNot == "A" || avlOrNot == "a")
            {
                avl = true;
            }
            else
            {
                avl = false;
            }
            Console.WriteLine("Enter Price:");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine();
            rest.Dishes.Add(new Dish(dishId, dishName, avl, price,rest.Id));

            Console.WriteLine("Do you want to add more dishes? (Type 'Y' for 'Yes')");
            string y = Console.ReadLine();
            if (y == "Y" || y == "y")
            {
                wantToAddDish = true;
                Console.WriteLine();
            }
        }
    }
    Restaurants.Add(rest);
}

void UpdateRestaurant()
{
    Console.WriteLine("Enter Id and Name of the Restaurant which you want to update");
    Console.WriteLine("Enter Id:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.WriteLine("Enter Name:");
    string restName = Console.ReadLine();
    Console.WriteLine();

    if (id != 0 && restName != null)
    {
        var rest = Restaurants.Where(rest => rest.Id == id && rest.RestaurantName == restName).FirstOrDefault();
        if (rest != null)
        {
            Console.WriteLine($"Restaurant Name : {rest.RestaurantName}");
            Console.WriteLine($"Restaurant Id : {rest.Id}");
            Console.WriteLine($"Open : {rest.Open}");
            Console.WriteLine($"UserId : {rest.UserId}");
            Console.WriteLine();
            Console.WriteLine("Do you want to update the above information? (Type 'Y' for Yes)");
            string y = Console.ReadLine();
            if (y == "Y" || y == "y")
            {
                bool wantToUpd = true;
                while(wantToUpd){
                    wantToUpd =false;
                    Console.WriteLine("What you want to update?");
                    Console.WriteLine("1. Restaurant Id");
                    Console.WriteLine("2. Restaurant name");
                    Console.WriteLine("3. Open");
                    Console.WriteLine("4. UserId");
                    int fieldToUpd = int.Parse(Console.ReadLine());
                    switch (fieldToUpd)
                    {
                        case 1:
                            Console.WriteLine("Enter new Id:");
                            int newId = int.Parse(Console.ReadLine());
                            rest.Id = newId;
                            break;
                        case 2:
                            Console.WriteLine("Enter new Name:");
                            string newName = Console.ReadLine();
                            rest.RestaurantName = newName;
                            break;
                        case 3:
                            if (rest.Open)
                            {
                                rest.Open = false;
                            }
                            else
                            {
                                rest.Open = true;
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter new UserId:");
                            int newUserId = int.Parse(Console.ReadLine());
                            rest.UserId = newUserId;
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Updated information");
                    Console.WriteLine($"Restaurant Name : {rest.RestaurantName}");
                    Console.WriteLine($"Restaurant Id : {rest.Id}");
                    Console.WriteLine($"Open : {rest.Open}");
                    Console.WriteLine($"UserId : {rest.UserId}");
                    Console.WriteLine();

                    Console.WriteLine("Do you still wish to update the above information? (Type 'Y' for Yes)");
                    string k = Console.ReadLine();
                    if (k == "Y" || k == "y")
                    {
                        wantToUpd = true;
                    }
                }

                

            }
            bool wantToUpdDishes = false;
            Console.WriteLine("Do you want to update dishes? (Type 'Y' for Yes)");
            string j = Console.ReadLine();
            if (j == "Y" || j == "y")
            {
                wantToUpdDishes = true;
            }
            while (wantToUpdDishes)
            {
                wantToUpdDishes = false;
                Console.WriteLine("Dishes: ");
                foreach (Dish dish in rest.Dishes)
                {
                    Console.WriteLine($"Dish Id : {dish.Id}");
                    Console.WriteLine($"Dish Name : {dish.DishName}");
                    Console.WriteLine($"Available : {dish.Available}");
                    Console.WriteLine($"Price : {dish.Price}");
                    Console.WriteLine();
                }

                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Add a dish");
                Console.WriteLine("2. Update a dish");
                Console.WriteLine("3. Delete a dish");
                int op = int.Parse( Console.ReadLine() );
                switch (op){
                    case 1:
                        Console.WriteLine("Enter Id of the Dish:");
                        int dishId = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        Console.WriteLine("Enter Dish Name:");
                        string dishName = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Is the Dish Available? Type 'A' for Available");
                        string avlOrNot = Console.ReadLine();
                        Console.WriteLine();
                        bool avl;
                        if (avlOrNot == "A" || avlOrNot == "a")
                        {
                            avl = true;
                        }
                        else
                        {
                            avl = false;
                        }
                        Console.WriteLine("Enter Price:");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        rest.Dishes.Add(new Dish(dishId, dishName, avl, price, rest.Id));
                        break;
                    case 2:
                        Console.WriteLine("Enter Id and Name of the Dish which you want to update");
                        Console.WriteLine("Enter Id:");
                        int dishIdToUpd = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Enter Name:");
                        string dishNameToUpd = Console.ReadLine();
                        Console.WriteLine();
                        var dishToUpd = rest.Dishes.FirstOrDefault(dish => dish.Id == dishIdToUpd && dish.DishName == dishNameToUpd);
                        if (dishToUpd != null)
                        {
                            Console.WriteLine("What you want to update?");
                            Console.WriteLine("1. Dish Id");
                            Console.WriteLine("2. Dish Name");
                            Console.WriteLine("3. Available");
                            Console.WriteLine("4. Price");
                            int dishFieldToUpd = int.Parse(Console.ReadLine());
                            switch (dishFieldToUpd)
                            {
                                case 1:
                                    Console.WriteLine("Enter new Id:");
                                    int newId = int.Parse(Console.ReadLine());
                                    dishToUpd.Id = newId;
                                    break;
                                case 2:
                                    Console.WriteLine("Enter new Name:");
                                    string newName = Console.ReadLine();
                                    dishToUpd.DishName = newName;
                                    break;
                                case 3:
                                    if (dishToUpd.Available)
                                    {
                                        dishToUpd.Available = false;
                                    }
                                    else
                                    {
                                        dishToUpd.Available = true;
                                    }
                                    break;
                                case 4:
                                    dishToUpd.PriceDropped += OnPriceDropped;
                                    void OnPriceDropped()
                                    {
                                        Console.WriteLine("Price dropped!");
                                    }
                                    Console.WriteLine("Enter new Price:");
                                    double newPrice = int.Parse(Console.ReadLine());
                                    dishToUpd.Price = newPrice;
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Id and Name of the Dish which you want to delete");
                        Console.WriteLine("Enter Id:");
                        int dishIdToDel = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Enter Name:");
                        string dishNameToDel = Console.ReadLine();
                        Console.WriteLine();
                        var dishToDel = rest.Dishes.FirstOrDefault(dish => dish.Id == dishIdToDel && dish.DishName == dishNameToDel);
                        if (dishToDel != null)
                        {
                            rest.Dishes.Remove(dishToDel);
                        }
                            break;
                }
                
                Console.WriteLine("Do you still want to update dishes? (Type 'Y' for Yes)");
                string m = Console.ReadLine();
                if (m == "Y" || m == "y")
                {
                    wantToUpdDishes = true;
                }
            }

            Console.WriteLine("Updated Restaurant : ");

            Console.WriteLine($"Restaurant Id : {rest.Id}");
            Console.WriteLine($"Restaurant Name : {rest.RestaurantName}");
            Console.WriteLine($"Open : {rest.Open}");
            Console.WriteLine($"UserId : {rest.UserId}");
            Console.WriteLine();
            Console.WriteLine("Dishes: ");
            foreach (Dish dish in rest.Dishes)
            {
                Console.WriteLine($"Dish Id : {dish.Id}");
                Console.WriteLine($"Dish Name : {dish.DishName}");
                Console.WriteLine($"Available : {dish.Available}");
                Console.WriteLine($"Price : {dish.Price}");
                Console.WriteLine();
            }
        }
    }
}
void DeleteRestaurant()
{

    Console.WriteLine("Enter Id and Name of the Restaurant which you want to delete");
    Console.WriteLine("Enter Id:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.WriteLine("Enter Name:");
    string restName = Console.ReadLine();
    Console.WriteLine();

    if (id != 0 && restName != null)
    {
        var rest = Restaurants.Where(rest => rest.Id == id && rest.RestaurantName == restName).FirstOrDefault();
        if (rest != null)
        {
            Restaurants.Remove(rest);
        }
    }
}









//void LoadJson()
//{
//    using (StreamReader r = new StreamReader("file1.json"))
//    {
//        string json = r.ReadToEnd();
//        List<FirstProject.Item> items = JsonConvert.DeserializeObject<List<FirstProject.Item>>(json);
//        foreach (var j in items)
//        {
//            Console.WriteLine(j.Itemname);
//        }
//    }
//}

//LoadJson();