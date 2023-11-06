using System.Reflection;

GameLoop gameLoop = new GameLoop();
List<Action> games = new List<Action>();

games.Add(gameLoop.HigherOrLower);
games.Add(gameLoop.BlackJack);

while (true)
{
    Console.Clear();
    Console.WriteLine("Pick a game to play!\r\n");
    Console.WriteLine("0: Higher or lower!");
    Console.WriteLine("1: Blackjack!");

    string d = Console.ReadLine();

    for (int i = 0; i < games.Count; i++)
    {
        if (d == i.ToString())
        {
            Console.Clear();
            games[i]();
        }
    }
}