namespace Shop.Requests.Order;

/// <summary>
/// Method for getting order information
/// </summary>
/// <param name="OrderId">order id</param>
public record GetInfoRequest(int OrderId);