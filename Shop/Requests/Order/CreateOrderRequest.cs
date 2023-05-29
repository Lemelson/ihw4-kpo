using Shop.Models;

namespace Shop.Requests.Order;

/// <summary>
/// Model for creating an order
/// </summary>
/// <param name="Signature">jwt token signature</param>
/// <param name="Dishes">Wish-dish list</param>
/// <param name="SpecialRequests">special requests</param>
public record CreateOrderRequest(string Signature, DishModel[] Dishes, string SpecialRequests);