using System.ComponentModel.DataAnnotations;

namespace PF.Estabelecimento.API.DTOs;

public class EstablishmentDto
{
    [Required]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(250, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A localização é obrigatória.")]
    [StringLength(250, ErrorMessage = "A localização deve ter no máximo {1} caracteres.")]
    public string Local { get; set; }

    [Required(ErrorMessage = "A URL da imagem é obrigatória.")]
    [StringLength(250, ErrorMessage = "A URL da imagem deve ter no máximo {1} caracteres.")]
    public string ImgURL { get; set; }

    [Required(ErrorMessage = "Os detalhes são obrigatórios.")]
    [StringLength(500, ErrorMessage = "Os detalhes devem ter no máximo {1} caracteres.")]
    public string Detail { get; set; }

    [Required(ErrorMessage = "A indicação de favorito é obrigatória.")]
    public bool Favorite { get; set; }

    [Required(ErrorMessage = "A quantidade de pessoas é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade de pessoas deve ser pelo menos {1}.")]
    public int QuantityPeople { get; set; }

    [Required(ErrorMessage = "O público nomeado é obrigatório.")]
    [StringLength(150, ErrorMessage = "O público nomeado deve ter no máximo {1} caracteres.")]
    public string NominatedAudience { get; set; }
}
