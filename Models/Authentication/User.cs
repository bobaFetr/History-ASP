using System.ComponentModel.DataAnnotations;

public class User
{
    public int UserId { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}