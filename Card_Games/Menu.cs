using System.Reflection;

GameLoop gameLoop = new GameLoop();
List<Action> games = new List<Action>();

games.Add(gameLoop.HigherOrLower);

string[] choice = new string[1] { "1" };
bool loop = true;

Console.WriteLine("Pick a game to play!\r\n");
Console.WriteLine("1: Higher or lower!");

while (loop)
{
    int i = 0;
    string d = Console.ReadLine();
    if(d == choice[i])
    {
        games[i](); 
    }
    i++;
}