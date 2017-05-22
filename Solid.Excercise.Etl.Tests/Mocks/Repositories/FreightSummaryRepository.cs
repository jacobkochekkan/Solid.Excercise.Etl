using Solid.Excercise.Etl.Interfaces;
using Solid.Excercise.Etl.Modals;

namespace Solid.Excercise.Etl.Tests.Mocks.Repositories
{
    class FreightSummaryRepository : IDeleteRepository<string, FreightByShipper>,
        IInsertRepository<string, FreightByShipper>
    {
        public void Delete(string input1, FreightByShipper input2)
        {
            // Do nothing
        }

        public void Insert(string input1, FreightByShipper input2)
        {
            // Do nothing
        }
    }
}
