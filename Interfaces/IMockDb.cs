using FirstApi.Classes;

namespace FirstApi.interfaces;

public interface IMockDb
{
    public ICollection<Animal> GetAllAnimals();
    public Animal? GetAnimalById(int id);
    public bool AddAnimal(Animal animal);

    public bool DeleteAnimal(int animalId);

    public ICollection<Visit>? GetAnimalVisit(int animalId);
    public bool AddVisit(Visit visit);
    public bool EditAnimal(int animalId,Animal animal);
}
