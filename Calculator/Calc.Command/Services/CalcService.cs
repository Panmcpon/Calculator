using Calc.Command.Exceptions;
using Calc.Command.Models;
using Calc.Command.Repositories;
using Serilog;
using System;
using System.Web.Mvc;

namespace Calc.Command.Services
{
    /// <summary>
    /// The CalcService consists method Operation.
    /// </summary>
    public class CalcService : ICalcRepository
    {
        public CalcService()
        {

        }

        /// <summary>
        /// The Operation method for Calculator which solves the examples: addition, substruction, multiplication and division.
        /// </summary>
        public double Operations(RequiredCalcModel requiredCalcModel)
        {
            if (requiredCalcModel == null)
            {
                Log.Error("ReqeiredCalcModel is empty");
                throw new ArgumentNullException(nameof(requiredCalcModel));
            }
            else if (requiredCalcModel.Operation != '+' && requiredCalcModel.Operation != '-' && requiredCalcModel.Operation != '*' && requiredCalcModel.Operation != '/')
            {
                Log.Error($"Not valid operation {requiredCalcModel.Operation}");
                throw new NotValidOperatorExeption($"Not valid operation {requiredCalcModel.Operation}");
            }
            else if (requiredCalcModel.Operation == '/' && Convert.ToInt32(requiredCalcModel.SecondOperand) == 0)
            {
                Log.Error($"Try to devide by {requiredCalcModel.SecondOperand}");
                throw new DevideByZeroExeption($"Try to devide by {requiredCalcModel.SecondOperand}");
            }
            else if (requiredCalcModel.Operation == '+')
            {
                double result = requiredCalcModel.FirstOperand + requiredCalcModel.SecondOperand;
                return result;
            }
            else if(requiredCalcModel.Operation == '-')
            {
                double result = requiredCalcModel.FirstOperand - requiredCalcModel.SecondOperand;
                return result;
            }
            else if (requiredCalcModel.Operation == '*')
            {
                double result = requiredCalcModel.FirstOperand * requiredCalcModel.SecondOperand;
                return result;
            }
            else if (requiredCalcModel.Operation == '/')
            {
                double result = requiredCalcModel.FirstOperand / requiredCalcModel.SecondOperand;
                return result;
            }
            return 0;
        }
    }
}
