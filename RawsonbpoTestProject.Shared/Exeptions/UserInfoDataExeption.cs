using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RawsonbpoTestProject.Shared.Exeptions
{
    public class UserInfoDataExeption: Exception
    {
        public UserInfoDataExeption() {}

        public UserInfoDataExeption(string message) : base(message) { }

        public UserInfoDataExeption(string message, Exception innerException) : base(message, innerException) { }

        public UserInfoDataExeption(string message, Type objectExeption) : base(message) 
        {
            Console.WriteLine($"{message}     {objectExeption.GetTypeInfo().Name}    {objectExeption.GetTypeInfo().Namespace}");
        }
    }
}
