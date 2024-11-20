using BusinessLayer.Facades;
using BusinessLayer.Services.Interfaces;
using Moq;

namespace Tests
{
    [TestFixture]
    public class ManufacturerFacadeTests
    {
        private Mock<IManufacturerService> _manufacturerServiceMock;
        private Mock<IProductService> _productServiceMock;
        private ManufacturerFacade _manufacturerFacade;

        [SetUp]
        public void SetUp()
        {
            _manufacturerServiceMock = new Mock<IManufacturerService>();
            _productServiceMock = new Mock<IProductService>();
            _manufacturerFacade = new ManufacturerFacade(_manufacturerServiceMock.Object, _productServiceMock.Object);
        }

        [Test]
        public void MergeManufacturersAsync_ShouldThrowInvalidOperationException_WhenIdsAreSame()
        {
            // Arrange //
            var manufacturerId = 1;

            // Act and Assert //
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _manufacturerFacade.MergeManufacturersAsync(manufacturerId, manufacturerId));
        }

        [Test]
        public void MergeManufacturersAsync_ShouldThrowKeyNotFoundException_WhenSourceDoesNotExist()
        {
            // Arrange //
            _manufacturerServiceMock.Setup(s => s.ValidateManufacturerAsync(1)).ReturnsAsync(false);
            _manufacturerServiceMock.Setup(s => s.ValidateManufacturerAsync(2)).ReturnsAsync(true);

            // Act and Assert //
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _manufacturerFacade.MergeManufacturersAsync(1, 2));
        }
    }
}