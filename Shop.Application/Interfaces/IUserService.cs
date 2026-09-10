namespace Shop.Application.Interfaces;

public interface IUserService
{
    Task<Result> CreateUserAsync(
     string UserName,
     string Email,
     string Password,
     string ConfirmedPassword,
     bool AcceptedTermsAndConditions);
}
