namespace dotnet_rpg.API.DTOs.Fight; 

public class FightRequestDto {
    public List<int> CharacterIds { get; set; } = new List<int>();
}