using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Calc.Command.Models
{
    public class RequiredCalcModel
    {
        [JsonProperty("firstOperand")]
        public double FirstOperand { get; set; }

        [JsonProperty("secondOperand")]
        public double SecondOperand { get; set; }

        [JsonProperty("operation")]
        public char Operation { get; set; }

        public RequiredCalcModel(int firstOperand, int secondOperand, char operation)
        {
            this.FirstOperand = firstOperand;
            this.SecondOperand = secondOperand;
            this.Operation = operation;
        }

        public RequiredCalcModel()
        {

        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            var that = (RequiredCalcModel)obj;
            if (this.FirstOperand != that.FirstOperand)
            {
                return false;
            }
            else if (this.SecondOperand != that.SecondOperand)
            {
                return false;
            }
            return this.Operation == that.Operation;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = FirstOperand.GetHashCode();
                hashCode = (hashCode * 397) ^ SecondOperand.GetHashCode();
                hashCode = (hashCode * 397) ^ Operation.GetHashCode();
                return hashCode;
            }
        }
    }
}
