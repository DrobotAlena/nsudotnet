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
            using (StreamWriter outputFileWriter = new StreamWriter("output.txt"))
            {
                int check = jsonSerializer.Serialize(testClass, outputFileWriter);
                switch (check)
                {
                    case 0:
                        Console.WriteLine("Successful serialize");
                        break;
                    case 1:
                        Console.WriteLine("Serialized object is null");
                        break;
                    case 2:
                        Console.WriteLine("Object, you want to serialize, not serializible");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
