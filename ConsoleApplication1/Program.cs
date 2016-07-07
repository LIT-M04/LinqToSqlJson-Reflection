using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { FirstName = "Avrumi", LastName = "Friedman", Age = 34 };
            string json = ConvertToJsonSimple(person);
            Console.WriteLine(json);
            Console.ReadKey(true);
        }

        static string ConvertToJsonSimple(object x)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            Type objType = x.GetType();
            PropertyInfo[] props = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < props.Length; i++)
            {
                PropertyInfo prop = props[i];
                builder.Append(prop.Name + ":");
                object value = prop.GetValue(x);
                string valueString = value.ToString();
                if (value is string)
                {
                    valueString = "\"" + valueString + "\"";
                }
                builder.Append(valueString);
                if (i < props.Length - 1)
                {
                    builder.Append(",");
                }

            }

            builder.Append("}");

            return builder.ToString();
        }
    }
}
