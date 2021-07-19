using System;

namespace ESGI.DesignPattern.Projet
{
    public abstract class AttributeDescriptorFactory
    {
        public static AttributeDescriptor Create(string descriptorName, Type mapperType, Type forType)
        {
            if (isDefaultDescriptor(forType))
            {
                return new DefaultDescriptor(descriptorName, mapperType, forType);
            }
            
            if (isReferenceDescriptor(forType))
            {
                return new ReferenceDescriptor(descriptorName, mapperType, forType);
            }

            throw new Exception($"invalid type for : {forType}");
        }
        
        private static bool isDefaultDescriptor(Type type)
        {
            return type == typeof(int) || type == typeof(DateTime);
        }  
        
        private static bool isReferenceDescriptor(Type type)
        {
            return type == typeof(User);
        }
    }
}