using DTO;
using Newtonsoft.Json;
using RestSharp;
using DataAccess.Crud;

namespace AppLogic
{
    public interface IEmployeeConnector
    {
        Task<List<Employee>> RetrieveAllEmployees();
        Task<List<Employee>> GetAllEmployeesRestSharp();
        Task<List<Employee>> GetAllEmployeesFlurl();
        Task<List<Employee>> GetAllManagers();
        Task<List<Employee>> GetOldestEmployee();
        Task<List<Employee>> GetNewestEmployee();
        Task<Employee?> GetEmployeeById(int id);
        Task<List<Employee>> GetEmployeesWithMoreThan(int years);
        Task<List<Employee>> GetEmployeesWithLessThan(int years);
        UserSessionDto? ValidateCredentials(string email, string password);
    }

    public class EmployeeConnector : IEmployeeConnector
    {
        private HttpClient? _httpClient;
        private const string _baseUrl = "https://rh-central.azurewebsites.net/";

        public EmployeeConnector()
        {
            InitializeHttpClient();
        }

        private void InitializeHttpClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_baseUrl),
                Timeout = TimeSpan.FromSeconds(15)
            };
        }

        public async Task<List<Employee>> RetrieveAllEmployees()
        {
            string serviceUrl = "/api/RH/GetAllEmployees";
            string result = await InvokeGetAsync(serviceUrl);
            var dtoEmployees = JsonConvert.DeserializeObject<List<Employee>>(result);

            return dtoEmployees ?? new List<Employee>();
        }

        public async Task<List<Employee>> GetAllManagers()
        {
            var employees = await RetrieveAllEmployees();

            // Un empleado es manager si existe al menos otro empleado que tenga su ID como ManagerId
            var managers = employees
                .Where(emp => employees.Any(other => other.ManagerId == emp.Id))
                .ToList();

            return managers;
        }

        public async Task<List<Employee>> GetOldestEmployee()
        {
            var employees = await RetrieveAllEmployees();

            if (!employees.Any())
                return new List<Employee>();

            var employeesWithDates = employees
                .Where(e => DateTime.TryParse(e.HiringDate, out _))
                .ToList();

            if (!employeesWithDates.Any())
                return new List<Employee>();

            var oldestHiringDate = employeesWithDates
                .Min(e => DateTime.Parse(e.HiringDate));

            return employeesWithDates
                .Where(e => DateTime.Parse(e.HiringDate) == oldestHiringDate)
                .ToList();
        }

        public async Task<List<Employee>> GetNewestEmployee()
        {
            var employees = await RetrieveAllEmployees();

            if (!employees.Any())
                return new List<Employee>();

            var employeesWithDates = employees
                .Where(e => DateTime.TryParse(e.HiringDate, out _))
                .ToList();

            if (!employeesWithDates.Any())
                return new List<Employee>();

            var newestHiringDate = employeesWithDates
                .Max(e => DateTime.Parse(e.HiringDate));

            return employeesWithDates
                .Where(e => DateTime.Parse(e.HiringDate) == newestHiringDate)
                .ToList();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            var employees = await RetrieveAllEmployees();
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public async Task<List<Employee>> GetEmployeesWithMoreThan(int years)
        {
            var employees = await RetrieveAllEmployees();
            var cutoffDate = DateTime.Now.AddYears(-years);

            return employees
                .Where(e => DateTime.TryParse(e.HiringDate, out var hiringDate) &&
                           hiringDate <= cutoffDate)
                .ToList();
        }

        public async Task<List<Employee>> GetEmployeesWithLessThan(int years)
        {
            var employees = await RetrieveAllEmployees();
            var cutoffDate = DateTime.Now.AddYears(-years);

            return employees
                .Where(e => DateTime.TryParse(e.HiringDate, out var hiringDate) &&
                           hiringDate >= cutoffDate)
                .ToList();
        }
        public UserSessionDto? ValidateCredentials(string email, string password)
        {
            var userCrud = new UserCrud();
            var user = userCrud.GetByEmail(email);

            if (user != null && user.PasswordHash == password)
            {
                return new UserSessionDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Rol = user.Rol
                };
            }
            return null;
        }

        #region Métodos Helpers
        private async Task<string> InvokeGetAsync(string uri)
        {
            try
            {
                if (_httpClient == null)
                {
                    InitializeHttpClient();
                }

                string responseString = string.Empty;
                var results = await _httpClient!.GetAsync(uri);
                if (results.IsSuccessStatusCode)
                {
                    responseString = await results.Content.ReadAsStringAsync();
                }

                return responseString;
            }
            catch (Exception e)
            {
                throw new Exception($"Error en InvokeGetAsync: {e.Message}", e);
            }
        }

        public Task<List<Employee>> GetAllEmployeesRestSharp()
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllEmployeesFlurl()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}