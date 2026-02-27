using Blagodat.Model;

public partial class Order
{
    public int Id { get; set; }
    public string OrderCode { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public TimeSpan CreatedTime { get; set; }
    public string ClientCode { get; set; } = null!;
    public string? Services { get; set; }
    public string Status { get; set; } = null!;
    public DateTime? ClosedDate { get; set; }
    public string RentalDuration { get; set; } = null!;

    public virtual Client? Client { get; set; }

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
}