using VirtualApp.Models;

namespace VirtualApp.Repositories.Base;

public interface IUpdateAsync
{
    Task<long> UpdateAsync(User user);
}