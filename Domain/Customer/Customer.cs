using Domain.Primitive;
using Domain.ValueObject;

namespace Domain.Customer
{
    public sealed class Customer : AggregateRoot
    {
        public Customer(CustomerId id, string primnerNombre, string segundoNombre, string primerApellido, string segundoApellido, string email, string password, object[] idicativoCelular, NumeroCelular numeroCelular, object[] idicativoWhatsapp, NumeroCelular numeroWhatsapp, object[] tipoDocumento, string numeroDocumento, Direccion direccion, string tokenAcceso, DateTime fechaCreacionTokenAcceso, string codigoValidacion, DateTime fechaCreacionCodigoValidacion, bool activo)
        {
            this.id = id;
            PrimnerNombre = primnerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Email = email;
            Password = password;
            IdicativoCelular = idicativoCelular;
            NumeroCelular = numeroCelular;
            IdicativoWhatsapp = idicativoWhatsapp;
            NumeroWhatsapp = numeroWhatsapp;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Direccion = direccion;
            TokenAcceso = tokenAcceso;
            FechaCreacionTokenAcceso = fechaCreacionTokenAcceso;
            CodigoValidacion = codigoValidacion;
            FechaCreacionCodigoValidacion = fechaCreacionCodigoValidacion;
            Activo = activo;
        }

        private Customer()
        {

        }


        public CustomerId id { get; private set; }
        public string PrimnerNombre { get; private set; } = string.Empty;
        public string SegundoNombre { get; private set; } = string.Empty;

        public string PrimerApellido { get; private set; } = string.Empty;

        public string SegundoApellido { get; private set; } = string.Empty;

        public string NombreCompleto => $"{PrimnerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}";

        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public object[] IdicativoCelular { get; private set; } = Array.Empty<object>();

        public NumeroCelular NumeroCelular { get; private set; }

        public object[] IdicativoWhatsapp { get; private set; } = Array.Empty<object>();

        public NumeroCelular NumeroWhatsapp { get; private set; }

        public object[] TipoDocumento { get; private set; } = Array.Empty<object>();
        public string NumeroDocumento { get; private set; } = string.Empty;

        public Direccion Direccion { get; private set; }

        public string TokenAcceso { get; private set; } = string.Empty;
        public DateTime FechaCreacionTokenAcceso { get; private set; }
        public string CodigoValidacion { get; private set; } = string.Empty;
        public DateTime FechaCreacionCodigoValidacion { get; private set; }
        public bool Activo {  get; private set; }



    }
}
