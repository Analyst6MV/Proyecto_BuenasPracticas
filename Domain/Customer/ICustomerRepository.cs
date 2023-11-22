namespace Domain.Customer
{
    public interface ICustomerRepository
    {

        Task<CustomerPersona?> GetCustomerPersonaById(int id);
        Task<CustomerEmpresa?> GetCustomerEmpresaById(int id);
        Task<DataLogin?> Login(string usuario ,string password);
        Task<DataLogin?> ActualizarToken(int id);
        Task<bool> RegistarToken(int id,string Token,DateTime fechaCreacion);
        Task<string> ValidarEmailYNombreUsuario(string nombreUsuario, string email);
        Task AddPersona(CustomerPersona customer);
        Task AddEmpresa(CustomerEmpresa customer);
    }
}
