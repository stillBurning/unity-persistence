using Assets.Scripts.Data;
using Assets.Scripts.Dto;
using Assets.Scripts.Persistance;
using Assets.Scripts.Persistance.Exceptions;
using System.Collections.Generic;
using System.Linq;


public class PlayerSettings : MonoSingleton<PlayerSettings>
{
    public PlayerData CurrentPlayer { get; private set; }

    public List<PlayerData> Highscores { get; private set; }

    public void Load()
    {
        var repo = new Repository<PlayerSettingsDto>();
        try
        {
            var gameDto = repo.Load();
            CurrentPlayer = gameDto.CurrentPlayer;
            Highscores = new List<PlayerData>();
            Highscores.AddRange(gameDto.HighScores);
        }
        catch (SaveNotFoundException)
        {
            CurrentPlayer = new PlayerData { Name = "Guest", Score = 0 };
            Highscores = new List<PlayerData>();
        }

        int c = 0;
        while (Highscores.Count < 5)
        {
            Highscores.Add(new PlayerData
            {
                Name = $"Anonymous-{++c}",
                Score = 0
            });
        }
        Highscores = Highscores.OrderByDescending(pd => pd.Score).ToList();
    }

    public void Save()
    {
        var repo = new Repository<PlayerSettingsDto>();
        repo.Save(new PlayerSettingsDto
        {
            CurrentPlayer = CurrentPlayer,
            HighScores = Highscores.ToArray()
        });
    }

    public void TryAddToTop5(int points)
    {
        if (Highscores.Min(pd => pd.Score) > points) return;
        Highscores.Add(new PlayerData
        {
            Name = CurrentPlayer.Name,
            Score = points
        });
        Highscores = Highscores
            .OrderByDescending(pd => pd.Score)
            .Take(5)
            .ToList();
    }
}
