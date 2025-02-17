namespace Trips.API.Contracts;

public record class ExceptionResponse(
    int StatusCode,
    string Message);
