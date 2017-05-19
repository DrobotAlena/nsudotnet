using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Drobot.Nsudotnet.Enigma
{
    class AlgorithmNameParser
    {
        public static SymmetricAlgorithm GetAlgorithmByName(String algorithmName)
        {
            SymmetricAlgorithm symmetricAlgorithm = null;
            String algorithmNameLoverCase = algorithmName.ToLower();
     
            switch (algorithmNameLoverCase)
            {

                case "aes":
                    symmetricAlgorithm = new System.Security.Cryptography.AesCryptoServiceProvider();
                    break;
                case "des":
                    symmetricAlgorithm = new System.Security.Cryptography.DESCryptoServiceProvider();
                    break;
                case "rc2":
                    symmetricAlgorithm = new System.Security.Cryptography.RC2CryptoServiceProvider();
                    break;
                case "rijndael":
                    symmetricAlgorithm = new System.Security.Cryptography.RijndaelManaged();
                    break;
            }
            return symmetricAlgorithm;
        }

    }
}
