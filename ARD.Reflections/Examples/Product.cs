using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARD.Reflections.Examples
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product()
        {
            //This is the default constructor.
        }
        public Product(int id, string name, string description, double price, double discount)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public void Display()
        {
            Console.WriteLine("Product Id: {0}, Price: {1}", Id, Price);
        }


        public static string CallingStaticMethodInProduct() 
        {
            return "This is CallingStaticMethodInProduct";
        }
    }
}
