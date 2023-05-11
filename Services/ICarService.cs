using MvcCars.Models;

public interface ICarService
{
    void CreateCar(Car entity);

    void UpdateCar(Car entity);

    void DeleteCar(Car entity);

    Car? GetCarById(int? id);

    IEnumerable<CarViewModel> GetAllCars();
}