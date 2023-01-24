using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.API.Controllers; 

[ApiController]
[Microsoft.AspNetCore.Components.Route("[controller]")]
public class FightController : ControllerBase {
    private readonly IFightService _fightService;

    public FightController(IFightService fightService) {
        _fightService = fightService;
    }
}