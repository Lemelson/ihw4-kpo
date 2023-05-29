namespace Auth.Requests.Account;

/// <summary>
/// Model for user registration
/// </summary>
/// <param name="Username">Username</param>
/// <param name="Email">Email</param>
/// <param name="Password">Password</param>
/// <param name="Role">Role</param>
public record RegisterRequest(string Username, string Email, string Password, string Role);