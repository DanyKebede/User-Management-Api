namespace WebApi.Contract;

public record UserCreateRequest(
    string FirstName,
    string LastName
);