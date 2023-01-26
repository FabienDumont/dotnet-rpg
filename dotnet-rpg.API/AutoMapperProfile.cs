using dotnet_rpg.API.DTOs.Fight;
using dotnet_rpg.API.DTOs.Skill;

namespace dotnet_rpg.API; 

public class AutoMapperProfile : Profile {
    public AutoMapperProfile() {
        CreateMap<Character, GetCharacterDto>();
        CreateMap<AddCharacterDto, Character>();
        CreateMap<Weapon, GetWeaponDto>();
        CreateMap<Skill, GetSkillDto>();
        CreateMap<Character, HighscoreDto>();
    }
}