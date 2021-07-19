﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        TestingDescriptorMapper testDescriptorMapper;

        public  Tests()
        {
            testDescriptorMapper = new TestingDescriptorMapper();
        }

        [Fact]
        public void it_maps_remoteId_descriptor_as_DefaultDescriptor()
        {
            var remoteIdDescriptor =
                testDescriptorMapper.GetMappedDescriptorFor("remoteId");

            Assert.IsType<DefaultDescriptor>(remoteIdDescriptor);
        }

        [Fact]
        public void it_maps_createdDate_descriptor_as_DefaultDescriptor()
        {
            var createdDateDescriptor =
                testDescriptorMapper.GetMappedDescriptorFor("createdDate");

            Assert.IsType<DefaultDescriptor>(createdDateDescriptor);
        }

        [Fact]
        public void it_maps_lastChangedDate_descriptor_as_DefaultDescriptor()
        {
            var lastChangedDateDescriptor =
                testDescriptorMapper.GetMappedDescriptorFor("lastChangedDate");

            Assert.IsType<DefaultDescriptor>(lastChangedDateDescriptor);
        }

        [Fact]
        public void it_maps_createdBy_descriptor_as_ReferenceDescriptor()
        {
            var createdByDescriptor =
                testDescriptorMapper.GetMappedDescriptorFor("createdBy");

            Assert.IsType<ReferenceDescriptor>(createdByDescriptor);
        }

        [Fact]
        public void it_maps_lastChangedBy_descriptor_ReferenceDescriptor()
        {
            var lastChangedByDescriptor =
                testDescriptorMapper.GetMappedDescriptorFor("lastChangedBy");

            Assert.IsType<ReferenceDescriptor>(lastChangedByDescriptor);
        }

        [Fact]
        public void it_maps_optimisticLockVersion_descriptor_as_DefaultDescriptor()
        {
            var optimisticLockVersionDescriptor =
                testDescriptorMapper.GetMappedDescriptorFor("optimisticLockVersion");

            Assert.IsType<DefaultDescriptor>(optimisticLockVersionDescriptor);
        }

        [Fact]
        public void it_does_not_map_unknown_descriptors()
        {
            var unknownDescriptor =
                testDescriptorMapper.GetMappedDescriptorFor("unknown");

            Assert.Null(unknownDescriptor);
        }
        
        
        [Fact]
        public void it_factory_return_defaultdescriptor_with_type_int()
        {
            var descriptor = AttributeDescriptorFactory.Create("toto", typeof(int), typeof(int));
            Assert.IsType<DefaultDescriptor>(descriptor);
        }
        
        [Fact]
        public void it_factory_return_defaultdescriptor_with_type_datetime()
        {
            var descriptor = AttributeDescriptorFactory.Create("toto", typeof(int), typeof(DateTime));
            Assert.IsType<DefaultDescriptor>(descriptor);
        }
        
        [Fact]
        public void it_factory_return_referencedescriptor_with_type_user()
        {
            var descriptor = AttributeDescriptorFactory.Create("toto", typeof(int), typeof(User));
            Assert.IsType<ReferenceDescriptor>(descriptor);
        }
        
        [Fact]
        public void it_factory_throw_exception_with_type_string()
        {
            Assert.Throws<Exception>(() => AttributeDescriptorFactory.Create("toto", typeof(int), typeof(String)));
        }
        
        [Fact]
        public void it_goldenmaster()
        {
            var goldenMaster = File.ReadLines("C:/Users/aymer/Documents/ESGI/4A/Semestre2/DesignPattern/DesignPatternProjetESGI/GoldenMaster.txt").ToArray();
            var descriptorList = new DescriptorMapperWrapper().GetAllAttributeDescriptors();
            
            for (int i = 0; i < goldenMaster.Length; i++)
            {
                Assert.Equal(goldenMaster[i], descriptorList[i].ToString());   
            }
        }
    }

    internal class TestingDescriptorMapper : DescriptorMapper
    {
        List<AttributeDescriptor> descriptors;

        public TestingDescriptorMapper()
        {
            descriptors = CreateAttributeDescriptors();
        }

        public AttributeDescriptor GetMappedDescriptorFor(string descriptorName)
        {
            return descriptors.Find(descriptor => descriptor.DescriptorName == descriptorName);
        }
    }
}

