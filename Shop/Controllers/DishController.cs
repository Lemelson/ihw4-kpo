using Data;
using Data.Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Requests.Dish;

namespace Shop.Controllers;

/// <summary>
/// Dish controller class
/// </summary>
[ApiController]
[Route("[controller]")]
public class DishController : ControllerBase
{
    /// <summary>
    /// Database context
    /// </summary>
    private readonly ApplicationDbContext _db;

    public DishController(ApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Method that checks if the user is a manager or not
    /// </summary>
    /// <param name="signature">Signature of jwt token</param>
    /// <returns>is user is manager</returns>
    private async Task<bool> CheckAccess(string signature)
    {
        var session = await _db
            .Sessions
            .FirstOrDefaultAsync(x => x.SessionToken == signature && x.ExpiresAt > DateTime.UtcNow);
        if (session == null)
        {
            return false;
        }
        var user = await _db.Users.FindAsync(session.UserId);
        return user!.Role == RoleTypes.Roles[2];
    }

    /// <summary>
    /// Method that returns a list of all available dishes in a restaurant
    /// </summary>
    /// <returns>All available dishes</returns>
    [HttpGet]
    [Route("/dishes/get_dishes")]
    public IEnumerable<Dish> GetDishes()
    {
        var dishes = _db.Dishes.Where(x => x.IsAvailable).ToArray();
        return dishes;
    }

    /// <summary>
    /// Method for creating a new dish
    /// </summary>
    /// <param name="request">New dish model</param>
    /// <returns>HTTP code</returns>
    [HttpPost]
    [Route("/dishes/create")]
    public async Task<IActionResult> CreateDish([FromForm] CreateDishRequest request)
    {
        if (!await CheckAccess(request.Signature))
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Access denied");
        }
        var dish = new Dish
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity,
            IsAvailable = request.Quantity > 0,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        await _db.Dishes.AddAsync(dish);
        await _db.SaveChangesAsync();
        return StatusCode(StatusCodes.Status200OK, "Dish created");
    }

    /// <summary>
    /// Method for removing a dish from the menu
    /// </summary>
    /// <param name="request">Model for removing a dish</param>
    /// <returns>HTTP code</returns>
    [HttpPost]
    [Route("/dishes/delete")]
    public async Task<IActionResult> DeleteDish([FromForm] DeleteDishRequest request)
    {
        if (!await CheckAccess(request.Signature))
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Access denied");
        }
        var dish = await _db.Dishes.FindAsync(request.DishId);
        if (dish == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Wrong id");
        }
        _db.Dishes.Remove(dish);
        await _db.SaveChangesAsync();
        return StatusCode(StatusCodes.Status200OK, "Dish deleted");
    }

    /// <summary>
    /// Method for correcting an already existing dish
    /// </summary>
    /// <param name="request">Model for changing the dish</param>
    /// <returns>HTTP code</returns>
    [HttpPatch]
    [Route("/dishes/edit")]
    public async Task<IActionResult> EditDish([FromForm] EditDishRequest request)
    {
        if (!await CheckAccess(request.Signature))
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Access denied");
        }
        var dish = await _db.Dishes.FindAsync(request.DishId);
        if (dish == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Wrong id");
        }
        // here the old value will be assigned to the dish if the new value is not entered or is entered incorrectly
        dish.Name = request.Name.Length == 0 ? dish.Name : request.Name;
        dish.Description = request.Description ?? dish.Description;
        dish.Price = request.Price <= 0 ? dish.Price : request.Price;
        dish.Quantity = request.Quantity <= 0 ? dish.Quantity : request.Quantity;
        dish.IsAvailable = dish.Quantity > 0;
        dish.UpdatedAt = DateTime.UtcNow;
        _db.Dishes.Update(dish);
        await _db.SaveChangesAsync();
        return StatusCode(StatusCodes.Status200OK, "Dish patched");
    }
}