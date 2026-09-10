using MediatR;
using Shop.Application.Common;

namespace Shop.Application.Features.Users.Commands;

public sealed record RegisterUserCommand(
     string UserName,
     string Email,
     string Password,
     string ConfirmedPassword,
     bool AcceptedTermsAndConditions
    ) : IRequest<Result>
{ }

   


