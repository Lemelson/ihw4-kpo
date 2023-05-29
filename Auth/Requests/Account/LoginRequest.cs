namespace Auth.Requests.Account;

/// <summary>
/// Model for user login
/// </summary>
/// <param name="Email">Email</param>
/// <param name="Password">Password</param>
public record LoginRequest(string Email, string Password);