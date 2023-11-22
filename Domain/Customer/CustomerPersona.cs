using Domain.Primitive;
using Domain.ValueObject;

namespace Domain.Customer
{
    public sealed class CustomerPersona : AggregateRoot
    {
        public CustomerPersona(int id, string nombreUsuario, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string email, string password, List<IndicativoNumeroCelular_Whatsapp> indicativoCelular, NumeroCelular numeroCelular, List<IndicativoNumeroCelular_Whatsapp> indicativoWhatsapp, NumeroCelular numeroWhatsapp,List<TipoDocumento> tipoDocumento, string numeroDocumento, List<Direccion> direccion, string? tokenAcceso, DateTime? fechaCreacionTokenAcceso, string? codigoValidacion, DateTime? fechaCreacionCodigoValidacion, bool estadoUsuario, bool sesionActiva)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            TipoUsuario = "Persona";
            Email = email;
            Password = password;
            IndicativoCelular = indicativoCelular;
            NumeroCelular = numeroCelular;
            IndicativoWhatsapp = indicativoWhatsapp;
            NumeroWhatsapp = numeroWhatsapp;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Direccion = direccion;
            TokenAcceso = tokenAcceso;
            FechaCreacionTokenAcceso = fechaCreacionTokenAcceso;
            CodigoValidacion = codigoValidacion;
            FechaCreacionCodigoValidacion = fechaCreacionCodigoValidacion;
            EstadoUsuario = estadoUsuario;
            SesionActiva = sesionActiva;
        }

        private CustomerPersona()
        {

        }


        public int Id { get; private set; }

        public string NombreUsuario { get; private set; } = string.Empty;
        public string PrimerNombre { get; private set; } = string.Empty;
        public string SegundoNombre { get; private set; } = string.Empty;

        public string PrimerApellido { get; private set; } = string.Empty;

        public string SegundoApellido { get; private set; } = string.Empty;
        public string TipoUsuario { get; private set; } = string.Empty;

        public string NombreCompleto => $"{PrimerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}";

        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; }

        public List<IndicativoNumeroCelular_Whatsapp> IndicativoCelular { get; private set; }

        public NumeroCelular NumeroCelular { get; private set; }

        public List<IndicativoNumeroCelular_Whatsapp> IndicativoWhatsapp { get; private set; }

        public NumeroCelular NumeroWhatsapp { get; private set; }

        public List<TipoDocumento> TipoDocumento { get; private set; } 
        public string NumeroDocumento { get; private set; } = string.Empty;

        public List<Direccion> Direccion { get; private set; }

        public string? TokenAcceso { get; private set; } = string.Empty;
        public DateTime? FechaCreacionTokenAcceso { get; private set; } = null;
        public string? CodigoValidacion { get; private set; } = string.Empty;
        public DateTime? FechaCreacionCodigoValidacion { get; private set; } = null;
        public bool EstadoUsuario {  get; private set; }
        public bool SesionActiva {  get; private set; }
   



    }
}
