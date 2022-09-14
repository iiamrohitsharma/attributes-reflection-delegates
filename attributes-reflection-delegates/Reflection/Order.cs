using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attributes_reflection_delegates.Reflection
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }

        public static int OrderValue { get; set; }

        public Order()
        {

        }

        public Order(int orderId, string orderStatus)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
        }

        public void DisplayOrder()
        {
            Console.WriteLine(OrderStatus);

        }

        static Order()
        {
            OrderValue = 5;
        }

        public interface IAmInterface
        {
            public int OId { get; set; }
        }

        public static string CallingStaticMethodInOrder()
        {
            return "This is CallingStaticMethodInOrder";
        }
    }
}
