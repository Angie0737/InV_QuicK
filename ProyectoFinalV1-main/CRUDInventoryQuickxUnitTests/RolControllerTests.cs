using CRUDInventoryQuick.Contracts;
using CRUDInventoryQuick.Controllers;
using CRUDInventoryQuick.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDInventoryQuickxUnitTests
{
    public class RolControllerTests
    {

        private readonly Mock<IRepository<ASPNETUSERROLE>> _mockRepository;
        private readonly AspNetRoleController _controller;

        public RolControllerTests()
        {
            _mockRepository = new Mock<IRepository<ASPNETUSERROLE>>();
            _controller = new AspNetRoleController(_mockRepository.Object);
        }


        [Fact]
        public async Task Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Index();
            await Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public async Task Index_ActionExecutes_ReturnsExactNumberOfCategories()
        {
            _mockRepository.Setup(r => r.GetAll())
                .ReturnsAsync(new List<ASPNETUSERROLE>() { new ASPNETUSERROLE(), new ASPNETUSERROLE(), new ASPNETUSERROLE() });

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var Rol = Assert.IsType<List<ASPNETUSERROLE>>(viewResult.Model);
            Assert.Equal(3, Rol.Count);

        }
    }
}
