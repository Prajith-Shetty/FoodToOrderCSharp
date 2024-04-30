using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class Orders
    {
        
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string orderDate;

        public string OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }


        private double orderAmount;

        public double OrderAmount
        {
            get { return orderAmount; }
            set { orderAmount = value; }
        }

        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

      

        public Orders()
        {

        }
        public Orders(int id, string orderDate, double orderAmount, int userId)
        {
            Id = id;
            OrderDate = orderDate;
            OrderAmount = orderAmount;
            UserId = userId;
        }
    }
}
