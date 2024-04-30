using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class OrderDetail
    {
       
        private int orderDetailId;

        public int OrderDetailId
        {
            get { return orderDetailId; }
            set { orderDetailId = value; }
        }

        
        private int dishID;

        public int DishID
        {
            get { return dishID; }
            set { dishID = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private int ordersId;

        public int OrdersId
        {
            get { return ordersId; }
            set { ordersId = value; }
        }

        


        public OrderDetail() { }

        public OrderDetail(int orderDetailId, int dishID, int quantity, int ordersId)
        {
            OrderDetailId = orderDetailId;
            DishID = dishID;
            Quantity = quantity;
            OrdersId = ordersId;
        }
    }
}
