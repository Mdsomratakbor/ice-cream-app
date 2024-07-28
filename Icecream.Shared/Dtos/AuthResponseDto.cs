namespace Icecream.Shared.Dtos
{
    public record AuthResponseDto(LoggedInUserDto user, string Token);
}
