namespace dotnet_rpg.API.DTOs.Weapon; 

public class GetWeaponDto {
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }
}