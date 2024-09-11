namespace StudyAPI.Model.Requests
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public IFormFile Photo { get; set; }
    }
}
