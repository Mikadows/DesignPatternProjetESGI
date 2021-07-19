using System;
using System.IO;

namespace ESGI.DesignPattern.Projet
{
    class Program
    {
        static void Main(string[] args)
        {

            var descriptorMapperWrapper = new DescriptorMapperWrapper();
            foreach (var attribute in descriptorMapperWrapper.GetAllAttributeDescriptors())
            {
                Console.WriteLine(attribute);
            }
           
        }
    }
}
