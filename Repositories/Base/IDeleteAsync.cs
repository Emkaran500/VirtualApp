namespace VirtualApp.Repositories.Base;

public interface IDeleteAsync
{
    Task DeleteAsync(int id);
}