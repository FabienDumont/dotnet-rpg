namespace dotnet_rpg.API.Data;

public class DataContext : DbContext {
    public DataContext(DbContextOptions<DataContext> options) : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        Utility.CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "Admin" },
            new User { Id = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "Joueur1" },
            new User { Id = 3, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "Joueur2" }
        );

        modelBuilder.Entity<Character>().HasData(
            new Character {
                Id = 1, Name = "Lancelot", Class = RpgClass.Knight, HitPoints = 100, Strength = 15, Defense = 10,
                Intelligence = 10, UserId = 2
            },
            new Character {
                Id = 2, Name = "Gandalf", Class = RpgClass.Cleric, HitPoints = 100, Strength = 10, Defense = 10,
                Intelligence = 15, UserId = 3
            }
        );

        modelBuilder.Entity<Weapon>().HasData(
            new Weapon { Id = 1, Name = "The Master Sword", Damage = 20, CharacterId = 1 },
            new Weapon { Id = 2, Name = "Crystal Wand", Damage = 5, CharacterId = 2 }
        );

        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Name = "Fireball", Damage = 30 },
            new Skill { Id = 2, Name = "Frenzy", Damage = 20 },
            new Skill { Id = 3, Name = "Blizzard", Damage = 50 }
        );

        modelBuilder.Entity<Character>().HasMany(p => p.Skills)
            .WithMany(p => p.Characters)
            .UsingEntity(j => j.HasData(
                new { CharactersId = 1, SkillsId = 1 },
                new { CharactersId = 2, SkillsId = 2 },
                new { CharactersId = 2, SkillsId = 3 }
            ));
    }

    public DbSet<Character> Characters => Set<Character>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Weapon> Weapons => Set<Weapon>();
    public DbSet<Skill> Skills => Set<Skill>();
}