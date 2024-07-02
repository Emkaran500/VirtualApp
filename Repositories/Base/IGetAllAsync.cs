namespace VirtualApp.Repositories.Base;

public interface IGetAllAsync<T>
{
    Task<IEnumerable<T>?> GetAllAsync();
}