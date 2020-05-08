using System;
using System.Runtime.InteropServices;

namespace Calc.Command.Exceptions
{
    /// <summary>
    /// The exception that is thrown not valid operation was occured.
    /// </summary>
    [ComVisible(true)]
    [Serializable]
    public class NotValidOperatorExeption : Exception
    {
        public NotValidOperatorExeption()
        {

        }

        public NotValidOperatorExeption(string message) : base(message)
        {

        }
    }
}
