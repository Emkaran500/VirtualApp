using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VirtualApp.Models;
using VirtualApp.Repositories.Base;

namespace VirtualApp.Controllers;

public class UserController : Controller
{
    private readonly IUserRepository userRepository;

    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    [HttpGet("/[controller]")]
    public async Task<IActionResult> Index()
    {
        var users = await userRepository.GetAllAsync();
        return base.View(users);
    }

    [HttpPost("[controller]/[action]")]
    public async Task<IActionResult> Create(User newUser)
    {
        await userRepository.CreateAsync(newUser);

        return base.View("Index");
    }

    [HttpGet("[controller]/[action]")]
    public async Task<IActionResult> Update(User user)
    {
        await userRepository.UpdateAsync(user);

        return base.View("Index");
    }

    [HttpGet("[controller]/[action]/{id?}")]
    public async Task<IActionResult> Delete(int id)
    {
        await userRepository.DeleteAsync(id);

        return base.View("Index");
    }
}