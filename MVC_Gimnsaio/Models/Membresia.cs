namespace MVC_Gimnsaio.Models;

public class Membresia
{
    public int idMembresia { get; set; }
    
    public string nombreMembresia { get; set; }
    
    public int duracionMembresia { get; set; } // 12 meses, o con un if puedo cambiar a un año y demás 
    
    public double precioMembresia { get; set; }
}