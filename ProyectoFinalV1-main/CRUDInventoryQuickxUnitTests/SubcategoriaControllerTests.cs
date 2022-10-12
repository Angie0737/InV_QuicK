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
    public class SubcategoriaControllerTests
    {
        private readonly Mock<IRepository<SUBCATEGORIum>> _mockRepository;
        private readonly SubcategoriaController _controller;
        private readonly IRepository<CATEGORIum> _CategoriaRepository;

        public SubcategoriaControllerTests()
        {
            _mockRepository = new Mock<IRepository<SUBCATEGORIum>>();
            _controller = new SubcategoriaController(_mockRepository.Object,_CategoriaRepository);
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
                .ReturnsAsync(new List<SUBCATEGORIum>() { new SUBCATEGORIum(), new SUBCATEGORIum(), new SUBCATEGORIum() });

            var result = await _controller.Index(); 

            var viewResult = Assert.IsType<ViewResult>(result);
            var subcategories = Assert.IsType<List<SUBCATEGORIum>>(viewResult.Model);
            Assert.Equal(3, subcategories.Count);

        }
    }
}
