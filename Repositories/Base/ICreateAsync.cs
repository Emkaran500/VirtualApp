using VirtualApp.Models;

namespace VirtualApp.Repositories.Base;

public interface ICreateAsync
{
    Task CreateAsync(User newUser);
}