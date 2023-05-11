using MvcCars.Data;
using MvcCars.Models;

namespace MvcCars.Services;

public class MarcaService: Repository<Marca>, IMarcaService 
{
    public MarcaService(CarContext context): base(context)
    {
        
    }
}