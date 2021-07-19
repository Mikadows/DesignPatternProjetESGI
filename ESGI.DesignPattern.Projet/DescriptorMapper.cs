using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class DescriptorMapper
    {
        private IList<DescriptorData> _datas = new List<DescriptorData>
        {
            new DescriptorData("remoteId", typeof(int)),
            new DescriptorData("createdDate", typeof(DateTime)),
            new DescriptorData("lastChangedDate", typeof(DateTime)),
            new DescriptorData("createdBy", typeof(User)),
            new DescriptorData("lastChangedBy", typeof(User)),
            new DescriptorData("optimisticLockVersion", typeof(int)),
        };
        
        protected List<AttributeDescriptor> CreateAttributeDescriptors() {
            var result = new List<AttributeDescriptor>();

            foreach (var row in _datas)
            {
                result.Add(AttributeDescriptorFactory.Create(row.descriptorName, GetClass(), row.forType));
            }
            
            return result;
        }

        private Type GetClass()
        {
            return typeof(DescriptorMapper);
        }
    }

    internal class DescriptorData
    {
        public string descriptorName { get; }
        public Type forType { get; }

        public DescriptorData(string descriptorName, Type forType)
        {
            this.descriptorName = descriptorName;
            this.forType = forType;
        }
    }
}