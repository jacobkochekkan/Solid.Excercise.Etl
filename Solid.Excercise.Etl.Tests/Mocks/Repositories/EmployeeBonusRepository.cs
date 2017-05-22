using Solid.Excercise.Etl.Interfaces;
using Solid.Excercise.Etl.Modals;

namespace Solid.Excercise.Etl.Tests.Mocks.Repositories
{
    class EmployeeBonusRepository : IDeleteRepository<string, Employee>,
        IInsertRepository<string, Employee>
    {
        public void Delete(string input1, Employee input2)
        {
           // Do Nothing
        }

        public void Insert(string input1, Employee input2)
        {
            // Do Nothing
        }
    }
}
