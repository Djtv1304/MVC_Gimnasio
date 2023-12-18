using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Gimnsaio.Models;

public class Miembro
{
    public int idMiembro { get; set; }

    public int idMembresia { get; set; }

    public string nombreMiembro { get; set; }

    public string apellidoMiembro { get; set; }

    public string emailMiembro { get; set; }

    public string passwordMiembro { get; set; }

    public DateTime fechaInscripcion { get; set; }

    [NotMapped]
    public string NombreCompleto
    {
        get { return nombreMiembro + " " + apellidoMiembro; }
    }
}
