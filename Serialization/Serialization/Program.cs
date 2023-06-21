using Newtonsoft.Json;
using Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

class Program
{
    public static void Main(string[] args)
    {
        var enemies = new List<Enemy>()
        {
            new Enemy()
            {
                EnemyName = "Gabriel",
                CommunityName = "MachineDefeater",
                Email = "fathersHand2020@gmail.com",
                DifficultyRank = 'A',
                Health = 750,
                KillingTime = new TimeSpan(0,4,30)
            },
            new Enemy()
            {
                EnemyName = "V2",
                CommunityName = "Machiner_Machine",
                Email = "cointosser2@gmail.com",
                DifficultyRank = 'B',
                Health = 600,
                KillingTime = new TimeSpan(0,3,15)
            },
            new Enemy()
            {
                EnemyName = "Minos Prime",
                CommunityName = "Judge",
                Email = "spiritPower@gmail.com",
                DifficultyRank = 'S',
                Health = 1450,
                KillingTime = new TimeSpan(0,3,15)
            },
            new Enemy()
            {
                EnemyName = "V2_OneHanded",
                CommunityName = "LesserMachine",
                Email = "grappler228@gmail.com",
                DifficultyRank = 'B',
                Health = 750,
                KillingTime = new TimeSpan(0,2,40)
            }
        };
        var enemyJson = JsonConvert.SerializeObject(enemies);
        File.WriteAllText("data.json",enemyJson);

        var jsonValue = File.ReadAllText("data.json");
        var copyEnemyList = JsonConvert.DeserializeObject<List<Enemy>>(jsonValue);
        foreach (var enemy in copyEnemyList)
        {
            enemy.PrintInfo();
        }
        Console.ReadKey();
    }
}
//var utfEnemy = JsonSerializer.SerializeToUtf8Bytes(enemies);


