using Domain.Primitive;


namespace Domain.Customer
{
    public sealed class DataLogin : AggregateRoot
    {
        public DataLogin(int id, string nombreUsuario, string tipoUsuario,string email, string password, string tokenAcceso, DateTime fechaCreacionTokenAcceso, bool sesionActiva)
        {
            _id = id;
            NombreUsuario = nombreUsuario;
            TipoUsuario = tipoUsuario;
            Email = email;
            Password = password;
            TokenAcceso = tokenAcceso;
            FechaCreacionTokenAcceso = fechaCreacionTokenAcceso;
            SesionActiva = sesionActiva;
        }

        private DataLogin()
        {

        }



        public int _id { get; private set; }
        public string NombreUsuario { get; private set; } = string.Empty;
        public string TipoUsuario { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string? TokenAcceso { get; private set; } = string.Empty;
        public DateTime? FechaCreacionTokenAcceso { get; private set; }
        public bool SesionActiva { get; private set; }


    }
}
