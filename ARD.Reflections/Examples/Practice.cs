using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace ARD.Reflections.Examples
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };
    }

    public class Practice<T> where T : class
    {
        public Practice()
        {
            // storing anonymous type information in Type 
            Type currentType = typeof(T);

            // to create instance of the type
            T product = (T)Activator.CreateInstance(typeof(T));
        
            Console.WriteLine(currentType);
            Console.WriteLine("\nNamespace name is = " + currentType.Namespace);
            Console.WriteLine("\nAssembly name is = " + currentType.Assembly.GetName().Name);
            Console.WriteLine("\nType name is = " + currentType.Name);
            Console.WriteLine("\nAttributes are " + currentType.Attributes.ToString());

            Console.WriteLine("\nAssembly Qualified Name is " + currentType.AssemblyQualifiedName.ToString());

            Console.WriteLine("\nBaseType is " + currentType.BaseType.ToString());

            Console.WriteLine("\nFullName is " + currentType.FullName.ToString());

            Console.WriteLine("\nMemberType is " + currentType.MemberType.ToString());

            Console.WriteLine("\nModule is " + currentType.Module.ToString());

            Console.WriteLine("\nIsClass is " + currentType.IsClass.ToString());

            Console.WriteLine("\nIsArray  " + currentType.IsArray.ToString());

            Console.WriteLine("\nIsInterface is " + currentType.IsInterface.ToString());

            Console.WriteLine("\nNamespace is " + currentType.Namespace.ToString());

            #region Properties details
            // to get properties information from the type
            PropertyInfo[] propertyInfos = currentType.GetProperties();

            if (propertyInfos.Count() > 0)
            {
                Console.WriteLine($"\n-Properties declared in the type-{currentType.Name}----------");

                // to fetch all properties name from the type
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    Console.WriteLine(propertyInfo.Name);
                }
            }

            #endregion

            #region Constructor details

            // to get constructor information from the type
            ConstructorInfo[] constructorInfos = currentType.GetConstructors();

            if (constructorInfos.Count() > 0)
            {
                Console.WriteLine($"\n-Constructor defined in the type-{currentType.Name}----------");

                // to fetch all constructor details from the type
                foreach (ConstructorInfo constructorInfo in constructorInfos)
                {
                    object result = null;
                    ParameterInfo[] parameters = constructorInfo.GetParameters();
                    List<object> parametersArray = null;

                    if (parameters.Length > 0)
                    {
                        parametersArray = new List<object>();
                        foreach (ParameterInfo parameterInfo in parameters)
                        {

                            if (parameterInfo.ParameterType == typeof(string))
                            { parametersArray.Add("Test"); }

                            if (parameterInfo.ParameterType == typeof(int))
                            { parametersArray.Add(10); }

                            if (parameterInfo.ParameterType == typeof(object))
                            { parametersArray.Add(true); }

                        }
                    }

                    result = constructorInfo.Invoke(parametersArray?.ToArray());

                    if (parameters.Length > 0)
                    {
                        StringBuilder result2 = new StringBuilder();
                        for (int index = 0; index < parameters.Length; index++)
                        {
                            if (index > 0)
                                result2.Append(", ");

                            var changed = StringExtensions.FirstCharToUpper(parameters[index].Name);
                            var dsfdsfs = result.GetType().GetProperty(changed).GetValue(result, null);

                            result2.Append(changed + " = " + dsfdsfs);
                        }

                        Console.WriteLine("after Invoking constructor " + constructorInfo.ToString() + " the output is " + result2);
                    }
                    else
                    {
                        Console.WriteLine("after Invoking constructor " + constructorInfo.ToString() + " the output is nothing");
                    }

                }
            }
            #endregion


            #region Method details
            // to get method information from the type
            MethodInfo[] methodInfos = currentType.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

            if (methodInfos.Count() > 0)
            {
                Console.WriteLine($"\n-Method defined in the type-{currentType.Name}----------");

                // to fetch method details from the type
                foreach (MethodInfo methodInfo in methodInfos)
                {

                    object result = null;
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    var size = parameters.Length;
                    List<object> parametersArray = null;
                    // object classInstance = Activator.CreateInstance(type2, null);

                    if (parameters.Length > 0)
                    {
                        int counter = 0;
                        parametersArray = new List<object>();
                        foreach (ParameterInfo parameterInfo in parameters)
                        {

                            if (parameterInfo.ParameterType == typeof(string))
                            { parametersArray.Add("Test"); }

                            if (parameterInfo.ParameterType == typeof(int))
                            { parametersArray.Add(10); }

                            if (parameterInfo.ParameterType == typeof(object))
                            { parametersArray.Add(true); }

                            counter++;
                        }

                    }

                    result = methodInfo.Invoke(product, parametersArray == null ? null : parametersArray.ToArray());
                    Console.WriteLine("after Invoking method " + methodInfo.Name + " the output is " + result);


                }
            }
            #endregion

            #region Interface details

            // to get interface information from the type

            Type[] interfaceInfos = currentType.GetInterfaces();

            if (interfaceInfos.Count() > 0)
            {
                Console.WriteLine($"\n-Interfaces defined in the type-{currentType.Name}----------");

                // to fetch method details from the type
                foreach (Type typeInfo in interfaceInfos)
                {
                    Console.WriteLine(typeInfo.Name);
                }
            }


            #endregion

            // to load outside assemblies file
            // Assembly assembly2 = Assembly.LoadFile(@"D:\Entities.dll");
            // Type type3 = assembly2.GetType("Entities.Product");
            // Product product2 = (Product)Activator.CreateInstance(type3);

        }
    }
}
