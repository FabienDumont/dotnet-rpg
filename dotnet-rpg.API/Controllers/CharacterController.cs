﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase {
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService) {
        _characterService = characterService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get() {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id) {
        return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto character) {
        return Ok(await _characterService.AddCharacter(character));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(
        UpdateCharacterDto updatedCharacter) {
        var response = await _characterService.UpdateCharacter(updatedCharacter);
        if (response.Data is null) {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id) {
        var response = await _characterService.DeleteCharacter(id);
        if (response.Data is null) {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpPost("Skill")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkill(
        AddCharacterSkillDto newCharacterSkill) {
        return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
    }
}