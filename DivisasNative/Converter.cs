using System;
namespace DivisasNative
{
    public class Converter
    {
        public static Exchange Convert(decimal pesos)
        {
            return new Exchange
            {
                Dollars = pesos / 2980M,
                Euros = pesos / 3201M,
                Pounds = pesos / 4324M,
            };
        }
    }
}
