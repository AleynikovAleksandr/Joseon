using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService yt = new OrderService();
            Product lipon = new Product("lipon", 456, 23);
            Product tion = new Product("tion", 2456, 67);

            Customer gh = new Customer("алексей", "alexey.smirnov@example.com", "гоголя 39", "пенза", "2367");
            Customer fg = new Customer("ольга", "olga.kuznetsova@example.com", "петропавлосков", "владивасток", "8907");

            Order order1 = new Order(lipon, gh);
            Order order2 = new Order(tion, fg);

            yt.AddOrder(order1);
            yt.AddOrder(order2);

            List<Order> ListOrders = yt.GetOrders();

           

            for (int i = 0; i < ListOrders.Count; i++)
            {
                Order fer = ListOrders[i];
                Customer costr = fer.customer;
                Product cons = fer.product;
                double TotalPrice = fer.CalculateTotalPrice();
                string address = costr.address.ToString();
                
                Console.WriteLine($"Заказ {i+1}");
               
                Console.WriteLine($"#Покупатель:\nИмя: {costr.Name}\nEmail: {costr.Email}\nАдрес: {address}\n");
               
                Console.WriteLine($"Товар:\nНазвание: {cons.Name}\nЦена за штуку: {cons.Price}\nКоличество: {cons.Quanity}\nОбщая стоимость: {TotalPrice}\n");
            }
            
            Console.ReadLine();
        }
    }
}
