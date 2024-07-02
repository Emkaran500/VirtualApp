using VirtualApp.Models;
using VirtualApp.Repositories.Base;
using System.Data.SqlClient;
using Dapper;
using System.Text;
using Npgsql;

namespace VirtualApp.Repositories;

public class UserDapperRepository : IUserRepository
{
    private readonly string connectionString = "Server=prodpostgre.postgres.database.azure.com;Database=postgres;Port=5432;User Id=kirisa;Password=Alekto134;Ssl Mode=Require;";

    public async Task CreateAsync(User newUser)
    {
        using var connection = new NpgsqlConnection(this.connectionString);

        await connection.ExecuteAsync(@$"Insert into Users(Name)
                                        Values('{newUser.Name}')");
    }

    public async Task DeleteAsync(int id)
    {
        using var connection = new NpgsqlConnection(this.connectionString);

        await connection.ExecuteAsync($"Delete From Users Where Users.Id = {id}");
    }

    public async Task<IEnumerable<User>?> GetAllAsync()
    {
        using var connection = new NpgsqlConnection(this.connectionString);

        return await connection.QueryAsync<User>("Select * from Users");
    }

    public async Task<long> UpdateAsync(User user)
    {
        using var connection = new NpgsqlConnection(this.connectionString);

        return await connection.ExecuteAsync($@"Update Users
                                                Set Name = '{user.Name}'
                                                Where Users.Id = {user.Id}");}
}