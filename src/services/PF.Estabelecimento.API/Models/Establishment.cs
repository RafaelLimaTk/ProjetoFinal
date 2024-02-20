using PF.Core.DomainObjects;

namespace PF.Estabelecimento.API.Models;

public class Establishment : Entity, IAggregateRoot
{
    public string Name { get; set; }
    public string Local { get; set; }
    public string ImgURL { get; set; }
    public string Detail { get; set; }
    public bool Favorite { get; set; }
    public int QuantityPeople { get; set; }
    public string NominatedAudience { get; set; }
}
