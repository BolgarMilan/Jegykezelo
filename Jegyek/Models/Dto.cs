namespace Jegyek.Models
{
    public class Dto
    {
        public record CreateUserDto(int jegy, string leiras, DateTime ido);
        public record UpdateUserDto(int jegy, string leiras, DateTime ido);
    }
}
