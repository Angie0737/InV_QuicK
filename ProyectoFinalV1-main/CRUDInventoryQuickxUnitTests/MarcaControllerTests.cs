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
    public class MarcaControllerTests
    {

        private readonly Mock<IRepository<MARCA>> _mockRepository;
        private readonly MarcaController _controller;

        public MarcaControllerTests()
        {
            _mockRepository = new Mock<IRepository<MARCA>>();
            _controller = new MarcaController(_mockRepository.Object);
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
                .ReturnsAsync(new List<MARCA>() { new MARCA(), new MARCA(), new MARCA() });

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var Marca = Assert.IsType<List<MARCA>>(viewResult.Model);
            Assert.Equal(3, Marca.Count);

        }
    }
}
