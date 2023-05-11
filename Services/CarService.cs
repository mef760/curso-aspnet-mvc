using Microsoft.EntityFrameworkCore;
using MvcCars.Data;
using MvcCars.Models;

namespace MvcCars.Services;

public class CarService: Repository<Car>, ICarService 
{
    public CarService(CarContext context): base(context)
    {
        
    }

    public void CreateCar(Car entity)
    {
        // logica verificar nombres repetidos
        var response = base.GetWithFilter(x => x.Modelo == entity.Modelo);
        
        if (response != null && response.Count() > 0){
            // no crea
            return;
        }
        // crear con el repositorio
        base.Create(entity);
    }

    public void DeleteCar(Car entity)
    {
        base.Delete(entity);
    }

    public IEnumerable<CarViewModel> GetAllCars()
    {
        var list = base.GetAll().Include(x => x.Marca).ToList();
        var listViewModel = new List<CarViewModel>();

        foreach (var item in list)
        {
            var obj = new CarViewModel{
                Modelo = item.Modelo,
                Marca = item.Marca != null ? item.Marca.Name : string.Empty,
                MarcaId = item.MarcaId,
                Dominio = item.Dominio,
                Color = item.Color,
                CarType = item.Type.ToString()
            };
            listViewModel.Add(obj);
        }

        return listViewModel;
    }

    public Car? GetCarById(int? id)
    {
        return base.GetById(id);
    }

    public void UpdateCar(Car entity)
    {
        base.Update(entity);
    }
}