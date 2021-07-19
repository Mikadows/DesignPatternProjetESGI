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
}