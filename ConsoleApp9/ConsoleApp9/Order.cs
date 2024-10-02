using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Order
    {
        public Product product;
        public Customer customer;
        public int quanity;
        public double TotalPrice;

        public Order(Product pr, Customer cu)
        {
            product = pr;
            customer = cu;
            quanity = product.Quanity;
        }

        public double CalculateTotalPrice()
        {
            TotalPrice = product.Quanity * product.Price;
            return TotalPrice;
        }
    }
    
    interface IOrderService
    {
        void AddOrder(Order order);
        void CancelOrder(Order order);
        List<Order> GetOrders();
    }
    class OrderService : IOrderService
    {
        private List<Order> ORDERS = new List<Order>();
        public void AddOrder(Order order)
        {
            ORDERS.Add(order);
        }
        public void CancelOrder(Order order)
        {
            ORDERS.Remove(order);
        }
        public List<Order> GetOrders()
        {
            return ORDERS;
        }
    }
}
