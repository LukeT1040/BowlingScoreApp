using System.Collections.Generic;
using System.Linq;

public class Frame
{
    // Store each roll for each player for the frame
    public List<int> Rolls { get; set; } = new List<int>();

    public void AddRoll(int pins)
    {
        Rolls.Add(pins);
    }

}