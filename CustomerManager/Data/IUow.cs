namespace CustomerManager.Data
{
    public interface IUow
    {
        IRepository<Models.Customer> Customers { get; }
        void SaveChanges();
    }
}
