using dotnet_rpg.API.DTOs.Fight;

namespace dotnet_rpg.API.Services.FightService; 

public interface IFightService {
    Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
    Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);
    Task<ServiceResponse<FightResultDto>> Fight(FightRequestDto request);
    Task<ServiceResponse<List<HighscoreDto>>> GetHighscore();
}