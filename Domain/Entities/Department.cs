namespace EmployeeManagement.Domain.Entities
{
    class Department
    {
        public string departmentName { get; private set; }
        public Guid Id { get; private set; }

        public Department(string dptName)
        {
            departmentName = dptName;

            if (string.IsNullOrWhiteSpace(dptName))
            { // If what was typed is null, empty, or consists only of spaces, an exception will be thrown.
                throw new ArgumentNullException("Invalid name entered! Please try again. ", nameof(dptName));
            }
            Id = Guid.NewGuid();
        }
    }
}