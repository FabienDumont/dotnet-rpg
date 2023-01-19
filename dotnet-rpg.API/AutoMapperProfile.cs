﻿namespace dotnet_rpg.API; 

public class AutoMapperProfile : Profile {
    public AutoMapperProfile() {
        CreateMap<Character, GetCharacterDto>();
        CreateMap<AddCharacterDto, Character>();
        CreateMap<Weapon, GetWeaponDto>();
    }
}