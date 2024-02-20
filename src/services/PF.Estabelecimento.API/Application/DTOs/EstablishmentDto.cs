using System.ComponentModel.DataAnnotations;

namespace PF.Estabelecimento.API.Application.DTOs;

public class EstablishmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Local { get; set; }
    public string ImgURL { get; set; }
    public string Detail { get; set; }
    public bool Favorite { get; set; }
    public int QuantityPeople { get; set; }
    public string NominatedAudience { get; set; }
}
