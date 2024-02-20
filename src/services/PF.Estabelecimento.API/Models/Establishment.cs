using PF.Core.DomainObjects;

namespace PF.Estabelecimento.API.Models;

public class Establishment : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Local { get; private set; }
    public string ImgURL { get; private set; }
    public string Detail { get; private set; }
    public bool Favorite { get; private set; }
    public int QuantityPeople { get; private set; }
    public string NominatedAudience { get; private set; }

    protected Establishment() { }

    public Establishment(
        Guid id, string name, string local, string imgUrl, string detail, bool favorite, int quantityPeople, string nominatedAudience)
    {
        Id = id;
        Name = name;
        Local = local;
        ImgURL = imgUrl;
        Detail = detail;
        Favorite = favorite;
        QuantityPeople = quantityPeople;
        NominatedAudience = nominatedAudience;
    }

    public void IsFavorite(bool favorite)
    {
        Favorite = favorite;
    }

    public void UpdateEstablishment(string name, string local, string imgUrl, string detail, bool favorite, int quantityPeople, string nominatedAudience)
    {
        Name = name;
        Local = local;
        ImgURL = imgUrl;
        Detail = detail;
        Favorite = favorite;
        QuantityPeople = quantityPeople;
        NominatedAudience = nominatedAudience;
    }
}
