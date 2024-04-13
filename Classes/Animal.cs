using FirstApi.Enums;
using FirstApi.interfaces;

namespace FirstApi.Classes;

public class Animal : IAnimal
{
    public int Id { get; set; }
    public string Name { get; set; } = "undefined";
    public AnimalCategory Category { get; set; }
    public double Weight { get; set; }
    public string CoatColor { get; set; } = "undefined";
    public void Update(IAnimal animal)
    {
        Name = animal.Name;
        Category = animal.Category;
        Weight = animal.Weight;
        CoatColor = animal.CoatColor;
    }
    
}