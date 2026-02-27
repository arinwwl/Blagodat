using Blagodat.Model;
using System.ComponentModel.DataAnnotations.Schema;

public partial class Client
{
    public int Id { get; set; }
    [Column("client_code")]
    public string ClientCode { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public DateTime BirthDate { get; set; }
    public string PostalCode { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}