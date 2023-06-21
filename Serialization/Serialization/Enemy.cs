using Newtonsoft.Json;

namespace Serialization;
[Serializable]
public class Enemy
{
    [JsonProperty("enemy_name")]
    public string EnemyName { get; set; }
    [JsonProperty("community_name")]
    public string CommunityName { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("difficulty_rank")]
    public char DifficultyRank { get; set; }
    [JsonProperty("health")]
    public int Health { get; set; }
    [JsonProperty("killing_time")]
    public TimeSpan KillingTime { get; set; }

    public Enemy()
    {
    }

    public Enemy(string enemyName, string communityName, string email, char difficultyRank, int health, TimeSpan killingTime)
    {
        EnemyName = enemyName;
        CommunityName = communityName;
        Email = email;
        DifficultyRank = difficultyRank;
        Health = health;
        KillingTime = killingTime;
    }

    public void PrintInfo()
    {
        Console.WriteLine("Enemy Information");
        Console.WriteLine("-----------------");
        Console.WriteLine($"Enemy Name: {EnemyName}");
        Console.WriteLine($"Community Name: {CommunityName}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Difficulty Rank: {DifficultyRank}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Killing Time: {KillingTime}\n");
    }
}