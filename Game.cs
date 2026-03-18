using System.Collections.Generic;

public class Game
{
    private List<Frame> frames = new List<Frame>();

    public void AddFrame(Frame frame)
    {
        frames.Add(frame);
    }

    public int CalculateScore()
    {
        int total = 0;
        List<int> allRolls = new List<int>();

        // add all rolls into one list
        foreach (var frame in frames)
            allRolls.AddRange(frame.Rolls);

        int rollIndex = 0;

        // loop for 10 frames
        for (int frameNumber = 0; frameNumber < 10; frameNumber++)
        {
            if (allRolls[rollIndex] == 10) // strike 10 + next 2 rolls
            {
                total += 10 + allRolls[rollIndex + 1] + allRolls[rollIndex + 2];
                rollIndex += 1;
            }
            else if (allRolls[rollIndex] + allRolls[rollIndex + 1] == 10) // spare 10 + next roll
            {
                total += 10 + allRolls[rollIndex + 2];
                rollIndex += 2;
            }
            else // open frame sum of two rolls
            {
                total += allRolls[rollIndex] + allRolls[rollIndex + 1];
                rollIndex += 2;
            }
        }

        return total;
    }


}