using System;

namespace ESGI.DesignPattern.Projet
{
    public abstract class AttributeDescriptor
    {
        readonly string descriptorName;
        readonly Type mapperType;
        readonly Type forType;

        protected AttributeDescriptor(string descriptorName, Type mapperType, Type forType)
        {
            this.descriptorName = descriptorName;
            this.mapperType = mapperType;
            this.forType = forType;
        }

        public string DescriptorName => descriptorName;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", descriptorName, mapperType, forType);
        }
    }

    public abstract class AttributeDescriptorFactory
    {
        public static AttributeDescriptor Create(string descriptorName, Type mapperType, Type forType)
        {
            if (forType == typeof(int) || forType == typeof(DateTime))
            {
                return new DefaultDescriptor(descriptorName, mapperType, forType);
            }
            
            if (forType == typeof(User))
            {
                return new ReferenceDescriptor(descriptorName, mapperType, forType);
            }

            throw new Exception($"invalid type for : {forType}");
        }
    }
}