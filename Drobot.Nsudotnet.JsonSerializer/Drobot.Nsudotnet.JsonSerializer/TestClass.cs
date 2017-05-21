using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Drobot.Nsudotnet.JsonSerializer
{
    [Serializable]
    class TestClass
    {
        public int i = 10;
        public string s = "hihihi";
        public bool b = true; 

        [NonSerialized] public String ignore = "Hello, I'm ERROR!"; // это поле не должно сериализоваться

        public int[] arrayMember = {1,2,3,4,5};

        public List<String> list = new List<String>();

        public Dictionary<int, String> dictionary = new Dictionary<int, String>();

        public TestClass() 
        {
            list.Add("fff");
            list.Add("dd");

            dictionary.Add(1,"alice");
            dictionary.Add(2, "eva");
            dictionary.Add(3, "bob");
        }
    }
}
