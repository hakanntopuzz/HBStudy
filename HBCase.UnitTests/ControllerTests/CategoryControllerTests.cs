using HBCase.Controllers;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBCase.UnitTests.ControllerTests
{
    public class CategoryControllerTests
    {
        #region members & setup
        Mock<IMediator> mediator;
        CategoryController controller;

        [SetUp]
        public void Initialize()
        {
            mediator = new Mock<IMediator>();
            controller = new CategoryController(mediator.Object);
        }
        #endregion

    }
}
