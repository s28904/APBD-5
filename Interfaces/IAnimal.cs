using FirstApi.Enums;

namespace FirstApi.interfaces;

public interface IAnimal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AnimalCategory Category { get; set; }
    public double Weight { get; set; }
    public string CoatColor { get; set; }


}