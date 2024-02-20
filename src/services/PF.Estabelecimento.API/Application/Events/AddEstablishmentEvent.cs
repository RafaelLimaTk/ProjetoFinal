using PF.Core.Messages;

namespace PF.Estabelecimento.API.Application.Events;

public class AddEstablishmentEvent : Event
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Local { get; set; }
    public string ImgURL { get; set; }
    public string Detail { get; set; }
    public bool Favorite { get; set; }
    public int QuantityPeople { get; set; }
    public string NominatedAudience { get; set; }

    public AddEstablishmentEvent(
        Guid id, string name, string local, string imgUrl, string detail, bool favorite, int quantityPeople, string nominatedAudience)
    {
        AggregateId = id;
        Id = id;
        Name = name;
        Local = local;
        ImgURL = imgUrl;
        Detail = detail;
        Favorite = favorite;
        QuantityPeople = quantityPeople;
        NominatedAudience = nominatedAudience;
    }
}
