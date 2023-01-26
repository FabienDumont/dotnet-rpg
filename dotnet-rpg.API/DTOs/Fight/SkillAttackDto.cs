namespace dotnet_rpg.API.DTOs.Fight; 

public class SkillAttackDto {
    public int AttackerId { get; set; }
    public int OpponentId { get; set; }
    public int SkillId { get; set; }
}