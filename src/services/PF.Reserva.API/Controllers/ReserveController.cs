using Microsoft.AspNetCore.Mvc;
using PF.Reserva.API.Application.Queries;
using PF.Reserva.API.Controllers.Base;

namespace PF.Reserva.API.Controllers;

public class ReserveController : MainController
{
    private IReserveQueries _reserveQueries;
    public ReserveController(IReserveQueries reserveQueries)
    {
        _reserveQueries = reserveQueries;
    }

    [HttpGet("reservas")]
    public async Task<IActionResult> GetAllReserve()
    {
        var reserve = await _reserveQueries.GetAll();

        return reserve == null ? NotFound() : CustomResponse(reserve);
    }
}
