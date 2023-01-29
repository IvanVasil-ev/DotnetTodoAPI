using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpTodoApi.Entities;

public class AccountEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is required!")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    [MinLength(6)]
    public string Password { get; set; }
}
