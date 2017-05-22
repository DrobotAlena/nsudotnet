using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Drobot.Nsudotnet.Enigma
{
    class Encryptor
    {
        public static void Encrypt(String inputFile, String algorithmName, String outputFile)
        {

            try
            {
                using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
                {
                    using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
                    {
                        using (var algorithm = AlgorithmNameParser.GetAlgorithmByName(algorithmName))
                        {

                            algorithm.GenerateIV();
                            algorithm.GenerateKey();

                            using (var encryptor = algorithm.CreateEncryptor())
                            {

                                using (var cryptoStream = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
                                {
                                    inputFileStream.CopyTo(cryptoStream);

                                    String keyFileName = inputFile.Replace(".txt", ".key.txt");
                                    String[] content = { Convert.ToBase64String(algorithm.IV), Convert.ToBase64String(algorithm.Key) };
                                    File.WriteAllLines(keyFileName, content);
                                }
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
