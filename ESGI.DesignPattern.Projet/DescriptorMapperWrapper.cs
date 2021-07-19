using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class DescriptorMapperWrapper : DescriptorMapper
    {
        List<AttributeDescriptor> descriptors;

        public DescriptorMapperWrapper()
        {
            descriptors = CreateAttributeDescriptors();
        }

        public AttributeDescriptor GetMappedDescriptorFor(string descriptorName)
        {
            return descriptors.Find(descriptor => descriptor.DescriptorName == descriptorName);
        }

        public List<AttributeDescriptor> GetAllAttributeDescriptors()
        {
            return descriptors;
        }
    }
}