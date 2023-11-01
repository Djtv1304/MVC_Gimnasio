namespace MVC_Gimnsaio.Models;

public class Visita
{
    public int idVisita {  get; set; }
    
    public DateTime fechaVisita {  get; set; }
    
    public int miembroId {  get; set; }

    public string descripcionVisita {  get; set; }
}
