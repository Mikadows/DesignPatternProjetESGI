using System;

namespace ESGI.DesignPattern.Projet
{
    public static class AttributeDescriptorFactory
    {
        public static AttributeDescriptor Create(string descriptorName, Type mapperType, Type forType)
        {
            switch (forType.Name)
            {
                case "Int32":
                case "DateTime":
                    return new DefaultDescriptor(descriptorName, mapperType, forType);
                case "User":
                    return new ReferenceDescriptor(descriptorName, mapperType, forType);
                default:
                    throw new Exception($"invalid type for : {forType}");
            }
            
            // if (IsDefaultDescriptor(forType))
            // {
            //     return new DefaultDescriptor(descriptorName, mapperType, forType);
            // }
            //
            // if (IsReferenceDescriptor(forType))
            // {
            //     return new ReferenceDescriptor(descriptorName, mapperType, forType);
            // }
            //throw new Exception($"invalid type for : {forType}");
        }
        
        // private static bool IsDefaultDescriptor(Type type)
        // {
        //     return type == typeof(int) || type == typeof(DateTime);
        // }  
        //
        // private static bool IsReferenceDescriptor(Type type)
        // {
        //     return type == typeof(User);
        // }
    }
}