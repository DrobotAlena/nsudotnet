using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drobot.Nsudotnet.Enigma
{
    class Program
    {
        static void Main(String[] args)
        {
            if ((args.Length == 4) && (args[0].Equals("encrypt")))
            {
                Encryptor.Encrypt(args[1], args[2], args[3]);
            }
            else if ((args.Length == 5) && (args[0].Equals("decrypt")))
            {
                Decryptor.Decrypt(args[1], args[2], args[3], args[4]);
            }
            else 
            {
                ShowRulesForArguments();
            }
        }

        public static void ShowRulesForArguments() 
        {
            Console.WriteLine("");
            Console.WriteLine("Для шифрования используйте: encrypt file_name algorithm_name output_file_name");
            Console.WriteLine("Для дешифрования используйте: decrypt decrypt_file_name algorithm_name key_file_name output_file_name");
            Console.ReadKey(false);
        }
    }
}
