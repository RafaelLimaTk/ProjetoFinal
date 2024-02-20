using Microsoft.AspNetCore.Mvc;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Controllers;

public class EstablishmentController : Controller
{
    private readonly IEstablishmentRepository _establishmentRepository;

    public EstablishmentController(IEstablishmentRepository establishmentRepository)
    {
        _establishmentRepository = establishmentRepository;
    }

    [HttpGet("estabelecimento/estabelecimentos")]
    public async Task<IEnumerable<Establishment>> Index()
    {
        return await _establishmentRepository.GetAll();
    }

    [HttpGet("estabelecimento/detalhe-estabelecimento/{id}")]
    public async Task<Establishment> EstablishmentDetail(Guid id)
    {
        return await _establishmentRepository.GetById(id);
    }
}
