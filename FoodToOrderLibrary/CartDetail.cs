using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class CartDetail
    {
        private int cartDetailId;

        public int CartDetailId
        {
            get { return cartDetailId; }
            set { cartDetailId = value; }
        }

        private int dishId;

        public int DishId
        {
            get { return dishId; }
            set { dishId = value; }
        }
        
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

       

        public CartDetail() { }
        public CartDetail(int cartdetailId, int dishId, int quantity)
        {
            CartDetailId = cartdetailId;
            DishId = dishId;
            Quantity = quantity;
        }

      
    }
}
