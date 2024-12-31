using Infrastructure.Repository.Interfaces;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UsersRep { get; }
        ICategoryRepository CategoriesRep { get; }
        IManufacturerRepository ManufacturersRep { get; }
        IOrderRepository OrdersRep { get; }
        IOrderItemRepository OrderItemsRep { get; }
        IProductRepository ProductsRep { get; }
        IProductImageRepository ProductImagesRep { get; }
        IAuditLogRepository ProductAuditsRep { get; }
        ILogRepository LogsRep { get; }
        IGiftCardRepository GiftCardsRep { get; }
        ICouponCodeRepository CouponCodesRep { get; }

        Task<int> SaveAsync();
        void BeginTransaction();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
