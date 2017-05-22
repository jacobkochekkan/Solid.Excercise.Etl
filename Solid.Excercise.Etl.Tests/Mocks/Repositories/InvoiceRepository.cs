using System.Collections.Generic;
using Solid.Excercise.Etl.Entities;
using Solid.Excercise.Etl.Interfaces;

namespace Solid.Excercise.Etl.Tests.Mocks.Repositories
{
    class InvoiceRepository : IGetRepository<string, Invoice>
    {
        public IEnumerable<Invoice> GetAll(string connectionString)
        {
            var invoices = new List<Invoice>
            {
                new Invoice {ShipperName = "Evergreen Marine Corporation", Freight = 987.98m},
                new Invoice {ShipperName = "Hapag-Lloyd", Freight = 123.32m},
                new Invoice {ShipperName = "East Asiatic Company", Freight = 159.95m},
                new Invoice {ShipperName = "Hansa Shipping", Freight = 268.24m}
            };

            return invoices;
        }
    }
}
