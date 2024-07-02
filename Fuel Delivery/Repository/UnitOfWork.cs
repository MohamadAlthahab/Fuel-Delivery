using Fuel_Delivery.Data;
using Fuel_Delivery.IRepository;

namespace Fuel_Delivery.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private IGenericRepository<User> _user;
        private IGenericRepository<Role> _role;
        private IGenericRepository<Driver> _driver;
        private IGenericRepository<Fuel> _fuel;
        private IGenericRepository<Admin> _admin;
        private IGenericRepository<Car> _car;
        private IGenericRepository<Order> _order;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IGenericRepository<User> User => _user ??= new GenericRepository<User>(_appDbContext);
        public IGenericRepository<Role> Role => _role ??= new GenericRepository<Role>(_appDbContext);
        public IGenericRepository<Driver> Driver => _driver ??= new GenericRepository<Driver>(_appDbContext);
        public IGenericRepository<Fuel> Fuel => _fuel ??= new GenericRepository<Fuel>(_appDbContext);
        public IGenericRepository<Admin> Admin => _admin ??= new GenericRepository<Admin>(_appDbContext);
        public IGenericRepository<Car> Car => _car ??= new GenericRepository<Car>(_appDbContext);
        public IGenericRepository<Order> Order => _order ??= new GenericRepository<Order>(_appDbContext);

        public void Dispose()
        {
            _appDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
