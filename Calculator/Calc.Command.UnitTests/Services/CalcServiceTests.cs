using Calc.Api.Controllers;
using Calc.Command.Exceptions;
using Calc.Command.Models;
using Calc.Command.Repositories;
using Calc.Command.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calc.Command.UnitTests.Services
{
    public class CalcServiceTests
    {
        [Theory]
        [InlineData(2, 2, '+', 4)]
        [InlineData(4, 2, '-', 2)]
        [InlineData(4, 2, '*', 8)]
        [InlineData(8, 2, '/', 4)]
        public void EqualsRequiredCalcModelTestOne(int firstOperandAct, int secondOperandAct, char operationAct, int resultExp)
        {
            var act = new CalcService();
            RequiredCalcModel requiredCalcModel = new RequiredCalcModel(firstOperandAct, secondOperandAct, operationAct);
            var res = act.Operations(requiredCalcModel);
            Assert.Equal(resultExp, res);
        }

        [Theory]
        [InlineData(2, 2, '+', 3)]
        [InlineData(8, 2, '-', 3)]
        [InlineData(4, 2, '*', 5)]
        [InlineData(2, 2, '/', 3)]
        public void EqualsRequiredCalcModelTestTwo(int firstOperandAct, int secondOperandAct, char operationAct, int resultExp)
        {
            var act = new CalcService();
            RequiredCalcModel requiredCalcModel = new RequiredCalcModel(firstOperandAct, secondOperandAct, operationAct);
            var res = act.Operations(requiredCalcModel);
            Assert.NotEqual(resultExp, res);
        }

        public class CheckCalculatorTests
        {
            private readonly ICalcRepository calcRepository = new CalcService();

            [Fact(DisplayName = "EqualsRequiredCalcModelTest for NotValidOperation")]
            public void EqualsRequiredCalcModelTestThree()
            {
                var act = new RequiredCalcModel(2, 2, '=');
                var controller = new CalcController(calcRepository);
                Assert.Throws<NotValidOperatorExeption>(() => controller.ControllerOperation(act));
            }

            [Fact(DisplayName = "EqualsRequiredCalcModelTest for DivideByZero")]
            public void EqualsRequiredCalcModelTestFour()
            {
                var act = new RequiredCalcModel(2, 0, '/');
                var controller = new CalcController(calcRepository);
                Assert.Throws<DevideByZeroExeption>(() => controller.ControllerOperation(act));
            }

            [Fact(DisplayName = "EqualsRequiredCalcModelTest for Null object")]
            public void EqualsRequiredCalcModelTestFive()
            {
                var controller = new CalcController(calcRepository);
                Assert.Throws<ArgumentNullException>(() => controller.ControllerOperation(null));
            }
        }
    }
}
