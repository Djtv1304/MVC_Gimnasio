using System.ComponentModel.DataAnnotations;

namespace MVC_Gimnsaio.Models;

public class Usuario
{
    [Key]
    public int idUsuario { get; set; }

    [Required]
    public string username { get; set; }

    [Required]
    public string password { get; set; }

    public bool isAuthenticated { get; set; }
}
