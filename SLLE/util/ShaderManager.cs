using System;
using System.Collections.Generic;
using System.Text;

namespace SLLE.util
{
    internal class ShaderManager
    {
        public static string LoadRaw(string path)
        {
            string source = "";

            try
            {
                using (StreamReader reader = new StreamReader("../../../Shaders/" + path))
                {
                    source = reader.ReadToEnd();
                }

                return source;
            }
            catch (Exception err)
            {
                Console.WriteLine("Faided to load shader!\n" + err.Message);

                return "$err";
            }
        }
    }
}
