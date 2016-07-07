using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var wc = new WebClient();
            wc.DownloadFile(
                "http://www.automationheroes.com/wp-content/uploads/2013/11/tumblr_static_cheese_205_1362800142.jpg",
                "cheese.jpg");

        }
    }
}
