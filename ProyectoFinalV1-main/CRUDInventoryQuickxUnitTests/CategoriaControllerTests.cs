using CRUDInventoryQuick.Contracts;
using CRUDInventoryQuick.Controllers;
using CRUDInventoryQuick.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Win32;
using Moq;
using System.Xml.Linq;
using Twilio.Rest.Api.V2010;
using Twilio.TwiML.Voice;
using Task = System.Threading.Tasks.Task;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace CRUDInventoryQuickxUnitTests
{
    public class CategoriaControllerTests
    {
        private readonly Mock<IRepository<CATEGORIum>> _mockRepository;
        private readonly CategoriaController _controller;


        public CategoriaControllerTests()
        {
            _mockRepository = new Mock<IRepository<CATEGORIum>>();
            _controller = new CategoriaController(_mockRepository.Object);
        }

        //Retornar todos los objetos
        [Fact]
        public async void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        //Retornar un numero exacto de objetos
        [Fact]
        public async void Index_ActionExecutes_ReturnsExactNumberOfCategories()
        {
            _mockRepository.Setup(r => r.GetAll())
                .ReturnsAsync(new List<CATEGORIum>() { new CATEGORIum(), new CATEGORIum(), new CATEGORIum(), new CATEGORIum() });

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var categories = Assert.IsType<List<CATEGORIum>>(viewResult.Model);
            Assert.Equal(4, categories.Count);

        }

        //Retornar Vista
        [Fact]
        public void CreateGET_ActionExecutes_ReturnsViewCreate()
        {

            var result = _controller.Create();
            Assert.IsType<ViewResult>(result);
        }

        

        //Crear Objeto
        [Fact]
        public async void CreatePOST_ModelStateValid_CreateCategoriaCalledOnce()
        {
            CATEGORIum cat = null;
            _mockRepository.Setup(r => r.Add(It.IsAny<CATEGORIum>()))
            .Callback<CATEGORIum>(x => cat = x);
            var categoria = new CATEGORIum
            {
                CategoriaId = 100,
                Estado = true,
                Nombre = "Kevin"
            };
            await _controller.Create(categoria);

            _mockRepository.Verify(x => x.Add(It.IsAny<CATEGORIum>()), Times.Once);
            Assert.Equal(cat.CategoriaId, categoria.CategoriaId);
            Assert.Equal(cat.Estado, categoria.Estado);
            Assert.Equal(cat.Nombre, categoria.Nombre);
        }

        //Retornar Index-Despues de Creacion
        [Fact]
        public async void CreatePOST_ActionExecuted_RedirectsToIndexAction()
        {
            var categoria = new CATEGORIum
            {
                CategoriaId = 100,
                Estado = true,
                Nombre = "Kevin"
            };
            var result = await _controller.Create(categoria);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        //Retornar vista
        [Fact]
        public async void Update_ActionExecuted_ReturnsViewEdit()
        {
            int CategoriaId = 2;
            bool Estado = true;
            string Nombre = "Kevin";

            var mockRepo = new Mock<IRepository<CATEGORIum>>();
            _mockRepository.Setup(repo => repo.GetById(CategoriaId)).ReturnsAsync(GetTestCategoriaRecord());
            var controller = new CategoriaController(mockRepo.Object);

            // Act
            var result = await _controller.Edit(CategoriaId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CATEGORIum>(viewResult.ViewData.Model);
            Assert.Equal(CategoriaId, model.CategoriaId);
            Assert.Equal(Estado, model.Estado);
            Assert.Equal(Nombre, model.Nombre);
        }
        //Metodo devolver un registro
        private CATEGORIum GetTestCategoriaRecord()
        {
            var r = new CATEGORIum
            {
                CategoriaId = 2,
                Estado = true,
                Nombre = "Kevin"
            };
            return r;
        }

        
    }

}