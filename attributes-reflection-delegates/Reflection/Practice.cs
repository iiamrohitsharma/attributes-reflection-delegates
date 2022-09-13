using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace attributes_reflection_delegates.Reflection
{
   
    public class Practice
    {
        public Practice()
        {
            // to get the type of object
            int i = 42;
            Type type = i.GetType();
            Console.WriteLine(type);

            // to assembly information of the type
            Assembly assembly = typeof(Product).Assembly;

            // storing anonymous type information in Type 
            Type type2 = typeof(Product);

            // to get properties information from the type
            PropertyInfo[] propertyInfos = type2.GetProperties();

            // to get constructor information from the type
            ConstructorInfo[] constructorInfo = type2.GetConstructors();

            // to get method information from the type
            MethodInfo[] methodInfos = type2.GetMethods();

            // to create instance of the type
            Product product = (Product)Activator.CreateInstance(typeof(Product),1,"D365","D365",45,50);

            Console.WriteLine(type2);
            Console.WriteLine(assembly);

            Console.WriteLine($"----------Properties declared in the type-{ type2 }----------");

            // to fetch all properties name from the type
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine(propertyInfo.Name);
            }

            Console.WriteLine($"----------Constructor defined in the type-{type2}----------");
            // to fetch all constructor details from the type
            foreach (ConstructorInfo c in constructorInfo)
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine($"-----------Method defined in the type-{type2}----------");
            // to fetch method details from the type
            foreach (MethodInfo methodInfo in methodInfos)
            {
                Console.WriteLine(methodInfo.Name);
            }

            // to load outside assemblies file
            // Assembly assembly2 = Assembly.LoadFile(@"D:\Entities.dll");
            // Type type3 = assembly2.GetType("Entities.Product");
            // Product product2 = (Product)Activator.CreateInstance(type3);

            Console.WriteLine($"-----------Invoke static method in the type-{type2}----------");

            var staticOutput = type2.GetMethod("CallingStaticMethodInProduct",BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
            Console.WriteLine(staticOutput);
        }
    }
}
