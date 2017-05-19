using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Drobot.Nsudotnet.Enigma
{
    class Decryptor
    {
        public static void Decrypt(String inputFile, String algorithmName, String keyFilaName, String outputFile)
        {
            try
            {
                using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
                {
                    using (var streamReader = new StreamReader(keyFilaName))
                    {
                        using (var outputFileStream = new FileStream(outputFile, FileMode.OpenOrCreate))
                        {

                            byte[] IV = Convert.FromBase64String(streamReader.ReadLine());
                            byte[] key = Convert.FromBase64String(streamReader.ReadLine());

                            var algorithm = AlgorithmNameParser.GetAlgorithmByName(algorithmName);
                            var decryptor = algorithm.CreateDecryptor(key, IV);

                            using (var cryptoStream = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
                            {
                                cryptoStream.CopyTo(outputFileStream);
                            }
                        }
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("При работе с данными файлами произошла ошибка. Проверьте порядок подачи аргументов, имена файлов и модификаторы доступа");
                Program.ShowRulesForArguments();
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Тип шифрования указан неверно. Проверьте тип шифрования и порядок аргументов");
                Program.ShowRulesForArguments();
            }
        }
    }
}
