using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Drobot.Nsudotnet.JsonSerializer
{
    class Program
    {

        public static void Main(String[] args) 
        {
            TestClass testClass = new TestClass();
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(testClass, "output.txt");
        }
    }
}
