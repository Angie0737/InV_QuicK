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
    public class PrecioControllerTests
    {
        private readonly Mock<IRepository<PRECIO>> _mockRepository;
        private readonly IRepository<PRODUCTO> _productosRepository;
        private readonly PrecioController _controller;

        public PrecioControllerTests()
        {
            _mockRepository = new Mock<IRepository<PRECIO>>();
            _controller = new PrecioController(_mockRepository.Object, _productosRepository);
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
                .ReturnsAsync(new List<PRECIO>() { new PRECIO(), new PRECIO(), new PRECIO() });

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var Precio = Assert.IsType<List<PRECIO>>(viewResult.Model);
            Assert.Equal(3, Precio.Count);

        }
    }
}