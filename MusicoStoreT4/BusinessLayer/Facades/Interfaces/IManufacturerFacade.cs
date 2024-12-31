namespace BusinessLayer.Facades.Interfaces
{
    public interface IManufacturerFacade
    {
        public Task MergeManufacturersAsync(int sourceManufacturerId, int targetManufacturerId, int modifiedById);
    }
}
