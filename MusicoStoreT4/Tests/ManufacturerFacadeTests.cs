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

        [Test]
        public void MergeManufacturersAsync_ShouldThrowKeyNotFoundException_WhenTargetDoesNotExist()
        {
            // Arrange //
            _manufacturerServiceMock.Setup(s => s.ValidateManufacturerAsync(1)).ReturnsAsync(true);
            _manufacturerServiceMock.Setup(s => s.ValidateManufacturerAsync(2)).ReturnsAsync(false);

            // Act and Assert //
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _manufacturerFacade.MergeManufacturersAsync(1, 2));
        }

        [Test]
        public async Task MergeManufacturersAsync_ShouldCallReassignAndDelete_WhenBothExist()
        {
            // Arrange //
            _manufacturerServiceMock.Setup(m => m.ValidateManufacturerAsync(It.IsAny<int>())).ReturnsAsync(true);
            var sequence = new MockSequence();

            _productServiceMock.InSequence(sequence)
                .Setup(p => p.ReassignProductsToManufacturerAsync(It.IsAny<int>(), It.IsAny<int>()));
            _manufacturerServiceMock.InSequence(sequence)
                .Setup(m => m.DeleteManufacturerAsync(It.IsAny<int>()));

            // Act //
            await _manufacturerFacade.MergeManufacturersAsync(1, 2);

            // Assert //
            _manufacturerServiceMock.Verify(m => m.ValidateManufacturerAsync(1), Times.Once);
            _manufacturerServiceMock.Verify(m => m.ValidateManufacturerAsync(2), Times.Once);

            _productServiceMock.Verify(p => p.ReassignProductsToManufacturerAsync(1, 2), Times.Once);
            _manufacturerServiceMock.Verify(m => m.DeleteManufacturerAsync(1), Times.Once);

            _productServiceMock.VerifyNoOtherCalls();
            _manufacturerServiceMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task MergeManufacturersAsync_ShouldReassignAllProductsToTargetManufacturer()
        {
            // Arrange //
            int sourceManufacturerId = 1;
            int targetManufacturerId = 2;

            _manufacturerServiceMock.Setup(m => m.ValidateManufacturerAsync(sourceManufacturerId)).ReturnsAsync(true);
            _manufacturerServiceMock.Setup(m => m.ValidateManufacturerAsync(targetManufacturerId)).ReturnsAsync(true);

            var productsToReassign = new List<int> { 101, 102, 103 };

            _productServiceMock.Setup(p => p.ReassignProductsToManufacturerAsync(sourceManufacturerId, targetManufacturerId))
                .Callback<int, int>((src, tgt) =>
                {
                    Assert.AreEqual(sourceManufacturerId, src, "Source manufacturer ID does not match.");
                    Assert.AreEqual(targetManufacturerId, tgt, "Target manufacturer ID does not match.");
                })
                .Returns(Task.CompletedTask);

            // Act //
            await _manufacturerFacade.MergeManufacturersAsync(sourceManufacturerId, targetManufacturerId);

            // Assert //
            _manufacturerServiceMock.Verify(m => m.ValidateManufacturerAsync(sourceManufacturerId), Times.Once);
            _manufacturerServiceMock.Verify(m => m.ValidateManufacturerAsync(targetManufacturerId), Times.Once);
            _productServiceMock.Verify(p => p.ReassignProductsToManufacturerAsync(sourceManufacturerId, targetManufacturerId), Times.Once);
            _manufacturerServiceMock.Verify(m => m.DeleteManufacturerAsync(sourceManufacturerId), Times.Once);

            _productServiceMock.VerifyNoOtherCalls();
            _manufacturerServiceMock.VerifyNoOtherCalls();
        }
    }
}