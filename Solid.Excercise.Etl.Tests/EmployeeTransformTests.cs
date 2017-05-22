using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Solid.Excercise.Etl.EmployeeEtl;
using Solid.Excercise.Etl.Entities;
using Solid.Excercise.Etl.Interfaces;
using Solid.Excercise.Etl.ShipperEtl;
using Solid.Excercise.Etl.Tests.Mocks.Repositories;
using Employee = Solid.Excercise.Etl.Modals.Employee;


namespace Solid.Excercise.Etl.Tests
{
    [TestClass]
    public class EmployeeTransformTests
    {
        private IGetRepository<string, Invoice> invoices;
        private StandardKernel kernel;
        private ShipperTransform shipperTransform;
        private EmployeeTransform employeeTransform;

        public EmployeeTransformTests()
        {
            kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind(typeof(ITransform<,>)).To(typeof(ShipperTransform)).Named("ShipperTransform");
            kernel.Bind(typeof(ITransformEmployee<,,>)).To(typeof(EmployeeTransform)).Named("EmployeeTransform");
            employeeTransform = kernel.Get(typeof(ITransformEmployee<,,>)) as EmployeeTransform;
            shipperTransform = kernel.Get(typeof(ITransform<,>)) as ShipperTransform;
        }

        [TestMethod]
        public void EmployeeTeansform_WhenValidInputsAerPassed_TransformEmployees()
        {
            List<Employee> expectedResult = new List<Employee>
            {
                new Employee{Name = "JacobEapen",Bonus = 1.53949m, IsManager = false},
                new Employee{Name = "EapenKochekkan",Bonus = 153.949m, IsManager = true},
            };
            expectedResult.Capacity = 2;
            var invoiceRepository = new InvoiceRepository();
            var employeeRepository = new EmployeeRepository();

            var shipperDetails = invoiceRepository.GetAll(null);
            var employees = employeeRepository.GetAll(null);
            var freightByShipper = shipperTransform.Transform(shipperDetails);

            var result = employeeTransform.Transform(employees, freightByShipper);

            result.ToList().Should().BeEquivalentTo(expectedResult);
        }
    }
}
