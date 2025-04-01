using DiplomaTests.Models;

namespace DiplomaTests.Utility
{
    public static class EmployeeData
    {
        public static readonly Employee PredefinedEmployee = new Employee
        {
            FirstName = "John",
            MiddleName = "Doe",
            LastName = "Smith",
            FullName = "John Doe",
            WholeName = "John Doe Smith"
        };
    }
}
