namespace dotnet_rpg.API.Services.WeaponService; 

public interface IWeaponService {
    Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
}