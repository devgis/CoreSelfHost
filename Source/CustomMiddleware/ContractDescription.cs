﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace DEVGIS.CustomMiddleware
{
    public class ContractDescription
    {
        public ServiceDescription Service { get; private set; }
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public Type ContractType { get; private set; }
        public IEnumerable<OperationDescription> Operations { get; private set; }

        public ContractDescription(ServiceDescription service, Type contractType, ServiceContractAttribute attribute)
        {
            Service = service;
            ContractType = contractType;
            Namespace = attribute.Namespace ?? "http://tempuri.org/"; // Namespace defaults to http://tempuri.org/
            Name = attribute.Name ?? ContractType.Name; // Name defaults to the type name

            var operations = new List<OperationDescription>();
            foreach (var operationMethodInfo in ContractType.GetTypeInfo().DeclaredMethods)
            {
                foreach (var operationContract in operationMethodInfo.GetCustomAttributes<OperationContractAttribute>())
                {
                    operations.Add(new OperationDescription(this, operationMethodInfo, operationContract));
                }
            }
            Operations = operations;
        }
    }
}
