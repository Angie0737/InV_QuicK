//using CRUDInventoryQuick.Contracts;
//using CRUDInventoryQuick.Controllers;
//using CRUDInventoryQuick.Models;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CRUDInventoryQuickxUnitTests
//{
//    public class ProductoControllerTests
//    {

//        private readonly Mock<IRepository<PRODUCTO>> _mockRepository;
//        private readonly ProductoController _controller;
       

//        public   ProductoControllerTests()
//        {
//            _mockRepository = new Mock<IRepository<PRODUCTO>>();
//            //_controller = new ProductoController(_mockRepository.Object);
//        }


//        [Fact]
//        public async Task Index_ActionExecutes_ReturnsViewForIndex()
//        {
//            var result = _controller.Index();
//            await Assert.IsType<Task<IActionResult>>(result);
//        }

//        [Fact]
//        public async Task Index_ActionExecutes_ReturnsExactNumberOfCategories()
//        {
//            _mockRepository.Setup(r => r.GetAll())
//                .ReturnsAsync(new List<PRODUCTO>() { new PRODUCTO(), new PRODUCTO(), new PRODUCTO() });

//            var result = await _controller.Index();

//            var viewResult = Assert.IsType<ViewResult>(result);
//            var productos = Assert.IsType<List<PRODUCTO>>(viewResult.Model);
//            Assert.Equal(3, productos.Count);

//        }
//    }
//}
