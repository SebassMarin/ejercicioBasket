using System;
using System.Collections.Generic;

public interface IPlayer
{
    string Name { get; }
    string Position { get; }
    int Performance { get; }
}

public class Player : IPlayer
{
    public string Name { get; private set; }
    public string Position { get; private set; }
    public int Performance { get; private set; }
 

    public Player(string name, string position, int performance)
    {
        Name = name;
        Position = position;
        
        Performance = Math.Max(0, Math.Min(10, performance));
    }
}


public class BasketballGame
{
    private List<IPlayer> players = new List<IPlayer>();
    private List<IPlayer> team1 = new List<IPlayer>();
    private List<IPlayer> team2 = new List<IPlayer>();
    private Random random = new Random();


    public void AddPlayer(IPlayer player)
    {
        players.Add(player);
    }

   
    public void SelectPlayers()
    {
      
        team1.Add(SelectRandomPlayer());
        team2.Add(SelectRandomPlayer());
        team1.Add(SelectRandomPlayer());
        team2.Add(SelectRandomPlayer());
        team1.Add(SelectRandomPlayer());
        team2.Add(SelectRandomPlayer());
    }

   
    private IPlayer SelectRandomPlayer()
    {
        int index = random.Next(players.Count);
        IPlayer selectedPlayer = players[index];
        players.RemoveAt(index);
        return selectedPlayer;
    }


    private int CalculateTeamScore(List<IPlayer> team)
    {
        int score = 0;
        foreach (var player in team)
        {
            score += player.Performance;
        }
        return score;
    }

   
    public void DetermineWinner()
    {
        int team1Score = CalculateTeamScore(team1);
        int team2Score = CalculateTeamScore(team2);

        Console.WriteLine($"Puntaje del Equipo 1: {team1Score}");
        Console.WriteLine($"Puntaje del Equipo 2: {team2Score}");

        if (team1Score > team2Score)
        {
            Console.WriteLine("¡El Equipo 1 es el ganador!");
        }
        else if (team1Score < team2Score)
        {
            Console.WriteLine("¡El Equipo 2 es el ganador!");
        }
        else
        {
            Console.WriteLine("¡Es un empate!");
        }
    }
}

class Program
{
    static void Main()
    {
        BasketballGame game = new BasketballGame();

        for (int i = 0; i < 6; i++)
        {
            Console.Write($"Ingrese el nombre del jugador {i + 1}: ");
            string name = Console.ReadLine();

            Console.Write($"Ingrese la posición del jugador {i + 1}: ");
            string position = Console.ReadLine();

            Console.Write($"Ingrese el rendimiento del jugador {i + 1} (0-10): ");
            int performance = int.Parse(Console.ReadLine());

            IPlayer player = new Player(name, position, performance);
            game.AddPlayer(player);
        }

        game.SelectPlayers();
        game.DetermineWinner();
    }
}
