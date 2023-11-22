namespace Domain.Customer
{
    public interface IIdCustomer
    {
        Task<int> UltimoID();
        Task ActualizarID(int ultimoid);
    }
}
