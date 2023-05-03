namespace MvcCars.Models;

public class Marca
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Made { get; set; }

    public virtual List<Car> Cars { get; set; }
}



