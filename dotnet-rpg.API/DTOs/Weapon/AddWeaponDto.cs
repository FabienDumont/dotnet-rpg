namespace dotnet_rpg.API.DTOs.Weapon; 

public class AddWeaponDto {
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }
    public int CharacterId { get; set; }
}