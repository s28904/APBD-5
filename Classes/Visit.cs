namespace FirstApi.Classes;

public class Visit
{
    public DateTime Date { get; set; }
    public int AnimalId { get; set; }
    public string VisitDescription { get; set; } = "no desc";
    public double VisitPrice { get; set; }

    
}