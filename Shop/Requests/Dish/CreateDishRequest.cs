namespace Shop.Requests.Dish;

/// <summary>
/// Model for creating a dish
/// </summary>
/// <param name="Signature">jwt token signature</param>
/// <param name="Name">dish name</param>
/// <param name="Description">dish description</param>
/// <param name="Price">dish price</param>
/// <param name="Quantity">dish quantity</param>
public record CreateDishRequest(string Signature, string Name, string? Description, decimal Price, int Quantity);