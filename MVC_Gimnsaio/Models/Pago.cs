namespace MVC_Gimnsaio.Models;

public class Pago
{
    public int idPago { get; set; }

    public int miembroId { get; set; }
    
    public DateTime fechaPago { get; set; }

    public double montoPago { get; set; }
    
    public string tipoTarjeta { get; set; }
    
    public string numeroTarjeta { get; set; }

    public string cvvTarjeta { get; set; }
    
    public DateTime caducidadTarjeta { get; set; }

    public string titularTarjeta { get; set; }
}