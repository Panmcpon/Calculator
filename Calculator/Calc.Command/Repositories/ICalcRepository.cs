using Calc.Command.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calc.Command.Repositories
{
    public interface ICalcRepository
    {
        public double Operations(RequiredCalcModel requiredCalcModel);
    }
}
