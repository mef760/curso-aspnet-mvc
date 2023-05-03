namespace MvcCars.Models;

public class Accesory 
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public virtual List<Car> Cars { get; set; }
}

