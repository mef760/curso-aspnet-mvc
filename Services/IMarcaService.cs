using MvcCars.Models;

namespace MvcCars.Services
{
    public interface IMarcaService
    {
        void Create(Marca entity);

        void Update(Marca entity);

        void Delete(Marca entity);

        Marca? GetById(int? id);

        IQueryable<Marca> GetAll();
    }
}