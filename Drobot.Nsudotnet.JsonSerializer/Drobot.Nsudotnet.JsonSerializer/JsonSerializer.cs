using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Collections;

namespace Drobot.Nsudotnet.JsonSerializer
{
    class JsonSerializer
    {

        public void Serialize(Object serializibedObject, String outputFileName) 
        {

            if (serializibedObject == null)
            {
                Console.WriteLine("Serialized object is null");
                Console.ReadKey();
                return;
            }

           
            Type t = serializibedObject.GetType();

            if (t.IsSerializable == false)
            {
                Console.WriteLine("Object, you want to serialize, not serializible");
                Console.ReadKey(false);
                return;
            }


            FieldInfo[] objectFields = t.GetFields();

            try
            {
                using (StreamWriter outputFileWriter = new StreamWriter(outputFileName))
                {
                    outputFileWriter.WriteLine("{");

                    foreach (FieldInfo objectFieldInfo in objectFields)
                    {
                        var nonSerialized = objectFieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), false);

                        if (nonSerialized.Length == 0)     //если поле Serialised
                        {
                            var objectFieldValue = objectFieldInfo.GetValue(serializibedObject);

                            if (objectFieldInfo.FieldType.IsPrimitive)
                            {
                                outputFileWriter.WriteLine(String.Format("\"{0}\": {1}", objectFieldInfo.Name, objectFieldValue.ToString()));
                            }
                            else if (objectFieldValue is String)
                            {
                                outputFileWriter.WriteLine(String.Format("\"{0}\": \"{1}\"", objectFieldInfo.Name, objectFieldValue.ToString()));
                            }
                            else if (objectFieldValue is IEnumerable)
                            {
                                StringBuilder arrayString = new StringBuilder();
                                arrayString.Append(String.Format("\"{0}\": [", objectFieldInfo.Name));
                                foreach (var value in (IEnumerable)objectFieldValue)
                                {
                                    arrayString.Append(value.ToString() + ",");
                                }
                                arrayString.Remove(arrayString.Length - 1, 1);
                                arrayString.Append("]");
                                outputFileWriter.WriteLine(arrayString);
                            }
                        }
                    }

                    outputFileWriter.WriteLine("}");
                    outputFileWriter.Flush();
                }
            }
            catch (System.ArgumentException) 
            {
                Console.WriteLine("incorrect output file name");
                Console.ReadKey(false);
            }
            
        }


    }
}
