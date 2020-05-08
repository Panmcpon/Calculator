using System;
using System.Runtime.InteropServices;

namespace Calc.Command.Exceptions
{
    /// <summary>
    /// The exception that is thrown when divide by zero was occured.
    /// </summary>
    [ComVisible(true)]
    [Serializable]
    public class DevideByZeroExeption : Exception
    {
        public DevideByZeroExeption()
        {

        }

        public DevideByZeroExeption(string message) : base(message)
        {

        }
    }
}
