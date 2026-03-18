public class Player
{
    public string Name { get; set; }
    public Game Game { get; set; }

    public Player(string name)
    {
        Name = name;
        Game = new Game();
    }
}