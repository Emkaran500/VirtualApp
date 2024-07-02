using VirtualApp.Models;

namespace VirtualApp.Repositories.Base;

public interface IUserRepository : IGetAllAsync<User>,
                                   ICreateAsync,
                                   IUpdateAsync,
                                   IDeleteAsync {}