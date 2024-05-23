using Fuel_Delivery.Data;

namespace Fuel_Delivery.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> User {  get; }
        IGenericRepository<Role> Role { get; }
        IGenericRepository<Driver> Driver { get; }
        IGenericRepository<Fuel> Fuel { get; }
        Task Save();
    }
}
