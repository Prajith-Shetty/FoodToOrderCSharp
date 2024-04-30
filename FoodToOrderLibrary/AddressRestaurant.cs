using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class AddressRestaurant
    {
        
        private string addressesId;

        public string AddressesId
        {
            get { return addressesId; }
            set { addressesId = value; }
        }

        private string restaurantsId;

        public string RestaurantsId
        {
            get { return restaurantsId; }
            set { restaurantsId = value; }
        }


        public AddressRestaurant() { }
        public AddressRestaurant(string addressesId, string restaurantsId)
        {
            AddressesId = addressesId;
            RestaurantsId = restaurantsId;
        }
    }
}
