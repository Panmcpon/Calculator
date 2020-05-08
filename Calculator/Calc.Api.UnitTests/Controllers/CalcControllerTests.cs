using Calc.Api.Controllers;
using Calc.Command.Exceptions;
using Calc.Command.Models;
using Calc.Command.Repositories;
using Calc.Command.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calc.Api.UnitTests.Controllers
{
    public class CalcControllerTests
    {
        private readonly ICalcRepository calcRepository = new CalcService();

        [Fact(DisplayName = "NotificationController test sucsess")]
        public void CalcTest1()
        {
            var requiredCalcModel = new RequiredCalcModel();
            requiredCalcModel.FirstOperand = 15;
            requiredCalcModel.SecondOperand = 10;
            requiredCalcModel.Operation = '/';
            calcRepository.Operations(requiredCalcModel);
            var controller = new CalcController(calcRepository);
            var act = controller.ControllerOperation(requiredCalcModel);
            Assert.IsType<OkObjectResult>(act);
        }

        [Fact(DisplayName = "NotificationController test false")]
        public void CalcTest2()
        {
            var requiredCalcModel = new RequiredCalcModel();
            var controller = new CalcController(calcRepository);
            Assert.Throws<NotValidOperatorExeption>(() => controller.ControllerOperation(requiredCalcModel));
        }
    }
}
