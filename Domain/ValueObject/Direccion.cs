
using System.Net;

namespace Domain.ValueObject
{
    public partial record Direccion
    {



        public Direccion(int idTipoVia, string tipoVia, string numeroVia, string apendiceVia, string numeroCruce, string apendiceCruce, string metrosEsquina, string descripcionAdicional, string codigoPostal, int idPais, int idDepartamento, int idCiudad)
        {


            IdTipoVia = idTipoVia;
            TipoVia = tipoVia;
            NumeroVia = numeroVia;
            ApendiceVia = apendiceVia;
            NumeroCruce = numeroCruce;
            ApendiceCruce = apendiceCruce;
            MetrosEsquina = metrosEsquina;
            DescripcionAdicional = descripcionAdicional;
            CodigoPostal = codigoPostal;
            IdPais = idPais;
            IdDepartamento = idDepartamento;
            IdCiudad = idCiudad;

    }

        public int IdTipoVia { get; init; }
        public string TipoVia { get; init; }

        public string NumeroVia { get; init; }
        public string ApendiceVia { get; init; }
        public string NumeroCruce { get; init; }
        public string ApendiceCruce { get; init; }
        public string MetrosEsquina { get; init; }
        public string DescripcionAdicional { get; init; }

        public string DireccionCompleta => $" {TipoVia} {NumeroVia}  {ApendiceVia} {NumeroCruce} {ApendiceCruce} {MetrosEsquina} " + DescripcionAdicional == string.Empty ? $"{DescripcionAdicional}":"";
        public string CodigoPostal { get; init; }
        public int IdPais { get; init; }
        public int IdDepartamento { get; init; }
        public int IdCiudad { get; init; }


        public static Direccion? Create(int idTipoVia, string tipoVia, string numeroVia, string apendiceVia, string numeroCruce, string apendiceCruce, string metrosEsquina, string descripcionAdicional, string codigoPostal, int idPais, int idDepartamento, int idCiudad)
        {
            if (int.IsNegative(idTipoVia) || idTipoVia == 0 || string.IsNullOrEmpty(tipoVia) ||
                string.IsNullOrEmpty(numeroVia) || string.IsNullOrEmpty(apendiceVia) ||
                string.IsNullOrEmpty(numeroCruce) || string.IsNullOrEmpty(apendiceCruce)||
                string.IsNullOrEmpty(metrosEsquina) || string.IsNullOrEmpty(codigoPostal) ||
                 int.IsNegative(idPais) || idPais == 0 || int.IsNegative(idDepartamento) || idDepartamento == 0 ||
                int.IsNegative(idCiudad) || idCiudad == 0
                )
            {
                return null;
            }
            var direccionCompleta = $" {tipoVia} {numeroVia}  {apendiceVia} {numeroCruce} {apendiceCruce} {metrosEsquina} " + descripcionAdicional == string.Empty ? $"{descripcionAdicional}" : "";

            return new Direccion(idTipoVia, tipoVia, numeroVia, apendiceVia, numeroCruce, apendiceCruce, metrosEsquina, descripcionAdicional, codigoPostal, idPais, idDepartamento, idCiudad);
        }
    }
}
