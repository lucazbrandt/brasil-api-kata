namespace BrasilApiKata.Domain.Holidays.Models;

public class Holiday
{
    public DateTime Date { get; }
    public string Name { get; }
    public string Type { get; }

    public Holiday(DateTime Date, string Name, string Type) {
        this.Date = Date;
        this.Name = Name;
        this.Type = Type;
    }
}
