using Calc.Command.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calc.Command.UnitTests.Models
{
    public class RequiredCalcModelTests
    {
        [Theory]
        [InlineData(2, 2, '+', 2, 2, '+', true)]
        [InlineData(2, 2, '+', 1, 2, '+', false)]
        [InlineData(2, 2, '+', 2, 1, '+', false)]
        [InlineData(2, 2, '+', 2, 2, '-', false)]
        public void EqualsRequiredCalcModelTestOne(int firstOperandAct, int secondOperandAct, char operationAct, int firstOperandExp, int secondOperandExp, char operationExp, bool resultExp)
        {
            var act = new RequiredCalcModel(firstOperandAct, secondOperandAct, operationAct);
            var exp = new RequiredCalcModel(firstOperandExp, secondOperandExp, operationExp);
            var result = act.Equals(exp);
            Assert.Equal(resultExp, result);
        }

        [Fact]
        public void EqualsTestTwo()
        {
            var act = new RequiredCalcModel(2, 5, '+');
            var res = act.Equals(null);
            Assert.False(res);
        }

        [Fact]
        public void EqualsTestThree()
        {
            var act = new RequiredCalcModel(3, 5, '+');
            Assert.True(act.Equals(act));
        }

        [Fact]
        public void EqualsTestFour()
        {
            var act = new RequiredCalcModel(4, 5, '+');
            var exp = "http/postgres";
            var res = act.Equals(exp);
            Assert.False(res);
        }

        [Theory]
        [InlineData(5, 5, '+', true)]
        public void GetHashCodeTestOne(int firstOperandAct, int secondOperandAct, char operationAct, bool resultExp)
        {
            var messagePage = new RequiredCalcModel(firstOperandAct, secondOperandAct, operationAct);
            var act = messagePage.GetHashCode();
            var exp = messagePage.GetHashCode();
            Assert.Equal(resultExp, act.Equals(exp));
        }

        [Theory]
        [InlineData(2, 5, '+', 2, 5, '+', true)]
        [InlineData(1, 5, '+', 1, 5, '-', false)]
        public void GetHashCodeTestTwo(int firstOperandAct, int secondOperandAct, char operationAct, int firstOperandExp, int secondOperandExp, char operationExp, bool resultExp)
        {
            var act = new RequiredCalcModel(firstOperandAct, secondOperandAct, operationAct).GetHashCode();
            var exp = new RequiredCalcModel(firstOperandExp, secondOperandExp, operationExp).GetHashCode();
            Assert.Equal(resultExp, act.Equals(exp));
        }
    }
}
