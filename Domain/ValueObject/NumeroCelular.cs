using System.Text.RegularExpressions;

namespace Domain.ValueObject
{
    public partial record NumeroCelular
    {
        private const int DefaultLenght = 10;

        private const string Pattern = @"^\d{10}$";

        private NumeroCelular(string value) => Value = value;


        public static NumeroCelular?  Create(string value)
        {

            if (string.IsNullOrEmpty(value) || !NumeroCelularRegex().IsMatch(value) || value.Length !=  DefaultLenght)
            {
                return null;
            }

            return new NumeroCelular(value);
        }

        public string Value {  get; init; }


        [GeneratedRegex(Pattern)]
        private static partial Regex NumeroCelularRegex();

    }
}
