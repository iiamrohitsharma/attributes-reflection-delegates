using System;
using System.Linq;
using System.Reflection;

namespace attributes_reflection_delegates.Reflection
{

    public class Practice<T> where T : class
    {
        public Practice()
        {

            // to get the type of object
            int i = 42;
            Type type = i.GetType();
            Console.WriteLine(type);

            // to assembly information of the type
            Assembly assembly = typeof(T).Assembly;

            // storing anonymous type information in Type 
            Type type2 = typeof(T);

            // to get properties information from the type
            PropertyInfo[] propertyInfos = type2.GetProperties();

            // to get constructor information from the type
            ConstructorInfo[] constructorInfo = type2.GetConstructors();

            // to get method information from the type
            MethodInfo[] methodInfos = type2.GetMethods();

            // to get interface information from the type
            Type[] interfaceInfos = type2.GetInterfaces();

            //Console.WriteLine("GetInterfaces are " + type2.GetInterfaces().ToString());

            // to create instance of the type
            T product = (T)Activator.CreateInstance(typeof(T));

            Console.WriteLine(type2);
            Console.WriteLine(assembly);


            if (propertyInfos.Count() > 0)
            {
                Console.WriteLine($"----------Properties declared in the type-{type2}----------");

                // to fetch all properties name from the type
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    Console.WriteLine(propertyInfo.Name);
                }
            }


            if (constructorInfo.Count() > 0)
            {
                Console.WriteLine($"----------Constructor defined in the type-{type2}----------");

                // to fetch all constructor details from the type
                foreach (ConstructorInfo c in constructorInfo)
                {
                    Console.WriteLine(c.ToString());
                }
            }

            if (methodInfos.Count() > 0)
            {
                Console.WriteLine($"-----------Method defined in the type-{type2}----------");

                // to fetch method details from the type
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    Console.WriteLine(methodInfo.Name);
                }
            }

            if (interfaceInfos.Count() > 0)
            {
                Console.WriteLine($"-----------Interfaces defined in the type-{type2}----------");

                // to fetch method details from the type
                foreach (Type typeInfo in interfaceInfos)
                {
                    Console.WriteLine(typeInfo.Name);
                }
            }


            // to load outside assemblies file
            // Assembly assembly2 = Assembly.LoadFile(@"D:\Entities.dll");
            // Type type3 = assembly2.GetType("Entities.Product");
            // Product product2 = (Product)Activator.CreateInstance(type3);

            Console.WriteLine($"-----------Invoke static method in the type-{type2}----------");

            //var staticOutput = type2.GetMethod("CallingStaticMethodInProduct",BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
            //Console.WriteLine(staticOutput);

            Console.WriteLine("Attributes are "+type2.Attributes.ToString());

            Console.WriteLine("Assembly Qualified Name are " + type2.AssemblyQualifiedName.ToString());

            Console.WriteLine("BaseType are " + type2.BaseType.ToString());

            Console.WriteLine("FullName are " + type2.FullName.ToString());

            Console.WriteLine("MemberType are " + type2.MemberType.ToString());

            Console.WriteLine("Module are " + type2.Module.ToString());

            Console.WriteLine("IsClass are " + type2.IsClass.ToString());

            Console.WriteLine("IsArray are " + type2.IsArray.ToString());

            Console.WriteLine("IsInterface are " + type2.IsInterface.ToString());

            Console.WriteLine("Namespace are " + type2.Namespace.ToString());
        }
    }
}
