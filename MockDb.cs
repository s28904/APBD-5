using FirstApi.Classes;
using FirstApi.Enums;
using FirstApi.interfaces;

namespace FirstApi;

public class MockDb : IMockDb
{
    private ICollection<Animal> _animals;
    private ICollection<Visit> _visits;

    public MockDb()
    {
        _animals = new List<Animal>
        {
            new Animal()
            {
                Id=0,
                Name = "Animal 1",
                Category = AnimalCategory.Cat,
                Weight = 40,
                CoatColor = "Black"
                
            },
            new Animal()
            {
                Id=1,
                Name = "Animal 2",
                Category = AnimalCategory.Dog,
                Weight = 40,
                CoatColor = "Blue"
                
            },
            
        };
        _visits = new List<Visit>()
        {
            new Visit()
            {
                Date = DateTime.Now,
                AnimalId = 1,
                VisitDescription = "Desc1",
                VisitPrice = 1000,
            },
            new Visit()
            {
                Date = DateTime.Now,
                AnimalId = 0,
                VisitDescription = "Desc2",
                VisitPrice = 10040,
            },
            new Visit()
            {
                Date = DateTime.Now,
                AnimalId = 0,
                VisitDescription = "Desc3-0",
                VisitPrice = 1000,
            }
        };
    }
    
    
    public ICollection<Animal> GetAllAnimals()
    {
        return _animals;
    }

    public bool AddAnimal(Animal animal)
    {
        if (_animals.FirstOrDefault(animalInList => animalInList.Id == animal.Id) == null)
        {
            _animals.Add(animal);
            return true;
        }
        else
        {
            return false;
        }

    }
    
    public Animal? GetAnimalById(int id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public ICollection<Visit>? GetAnimalVisit(int animalId)
    {
        if (_animals.FirstOrDefault(animal => animal.Id == animalId) is null)
        {
            return null;
        }

        ICollection<Visit> animalVisits = new List<Visit>();
        foreach (var visit  in _visits)
        {
            if (visit.AnimalId == animalId)
            {
                animalVisits.Add(visit);
            }
        }

        return animalVisits;
    }

    public bool AddVisit(Visit visit)
    {
        var animalOnVisit = _animals.FirstOrDefault(animal => animal.Id == visit.AnimalId);
        if (animalOnVisit != null)
        {
            _visits.Add(visit);
            return true;
        }

        return false;
    }

    public bool DeleteAnimal(int animalId)
    {
        var animalToBeDeleted = _animals.FirstOrDefault(animal => animal.Id == animalId);
        if(animalToBeDeleted != null)
        {
            _animals.Remove(animalToBeDeleted);
            _visits = _visits.Where(visit => visit.AnimalId != animalId).ToList();
            return true;
        }

        return false;
    }

    public bool EditAnimal(int animalToBeUpdatedId,Animal animalUpdated)
    {
        var animalToBeEdited = _animals.FirstOrDefault(animal => animal.Id == animalToBeUpdatedId);
        if (animalToBeEdited != null)
        {
            animalToBeEdited.Update(animalUpdated);
            return true;
        }
        return false;
    }
    



}