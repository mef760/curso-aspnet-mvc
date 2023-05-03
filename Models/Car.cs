using MvcCars.Utils;

namespace MvcCars.Models;

public class Car 
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public CarType Type { get; set; }
    public string Dominio { get; set; }
    public string Color { get; set; }

    public int MarcaId { get; set; }
    public virtual Marca Marca { get; set; }


    public virtual List<Accesory> Accesories { get; set; }
}

