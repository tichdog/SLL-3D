using SLLE.src;
using System;

namespace SLLE
{
    /// <summary> Точка входа </summary>
    internal class Start
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Program...");

            using (Program Program = new Program(500, 500))
            {
                Program.Run();
            }

        }
    }
}