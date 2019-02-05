using System;
using System.Security.Cryptography;
using System.Text;

namespace HashGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string you wish to encode");
            string code = Console.ReadLine();

            Console.WriteLine("Enter the string you wish to use as a Key:");
            string key = Console.ReadLine();

            Console.WriteLine("Enter how many times you wish to run the hashing (between 1 and 100.000):");

            try
            {
                int runs = int.Parse(Console.ReadLine());
                for (int i = 0; i < runs; i++)
                {
                    code = sha256(code + key);
                }
                Console.WriteLine("Your encrypted code:");
                Console.WriteLine(code);
                Console.ReadLine();
            }
            catch (Exception)
            {
            }            
        }

        //Using the SHA256 cryptography
        static string sha256(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
