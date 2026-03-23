namespace EmployeeManagement.Domain.Entities
{
    class Department
    {
        public string departmentName { get; private set; }
        public Guid Id { get; private set; }
        public Department(string depName)
        {
            departmentName = depName;

            if (string.IsNullOrWhiteSpace(depName))
            { // If what was typed is null, empty, or consists only of spaces, an exception will be thrown.
                throw new ArgumentNullException("Invalid name entered! Please try again. ", nameof(depName));
            }
            Id = Guid.NewGuid();
        }
    }
}