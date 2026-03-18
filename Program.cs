using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bowling Score Calculator\n");

        int playerCount = GetPlayerCount();
        List<Player> players = GetPlayers(playerCount);

        // Loop through 10 frames
        for (int frameNumber = 1; frameNumber <= 10; frameNumber++)
        {
            Console.WriteLine($"\n--- Frame {frameNumber} ---");

            foreach (var player in players)
            {
                Console.WriteLine($"\n{player.Name}'s turn:");

                Frame frame = new Frame();

                int roll1 = GetRollInput("Roll 1: ", 10);
                frame.AddRoll(roll1);

                if (frameNumber == 10)
                {
                    HandleTenthFrame(frame, roll1);
                }
                else
                {
                    if (roll1 != 10)
                    {
                        int roll2 = GetRollInput("Roll 2: ", 10 - roll1);
                        frame.AddRoll(roll2);
                    }
                }

                player.Game.AddFrame(frame);
            }
        }

        // Final scores
        Console.WriteLine("\n=== Final Scores ===");
        foreach (var player in players)
        {
            int score = player.Game.CalculateScore();
            Console.WriteLine($"{player.Name}: {score}");
        }
    }

    static int GetPlayerCount()
    {
        while (true)
        {
            Console.Write("How many players (1-4): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a number.");
                continue;
            }

            if (!int.TryParse(input, out int count))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            if (count < 1 || count > 4)
            {
                Console.WriteLine("Please enter a number between 1 and 4.");
                continue;
            }

            return count;
        }
    }

    static List<Player> GetPlayers(int count)
    {
        List<Player> players = new List<Player>();

        for (int i = 1; i <= count; i++)
        {
            Console.Write($"Enter name for Player {i}: ");
            string name = Console.ReadLine();

            players.Add(new Player(name));
        }

        return players;
    }

    static int GetRollInput(string message, int maxPins)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a number.");
                continue;
            }

            if (!int.TryParse(input, out int pins))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            if (pins < 0 || pins > maxPins)
            {
                Console.WriteLine($"Pins must be between 0 and {maxPins}.");
                continue;
            }

            return pins;
        }
    }

    static void HandleTenthFrame(Frame frame, int roll1)
    {
        if (roll1 == 10) // strike
        {
            int roll2 = GetRollInput("Roll 2: ", 10);
            frame.AddRoll(roll2);

            // If second roll isn't strike, limit third roll
            int roll3Max = (roll2 == 10) ? 10 : 10 - roll2;
            int roll3 = GetRollInput("Roll 3: ", roll3Max);
            frame.AddRoll(roll3);
        }
        else
        {
            int roll2 = GetRollInput("Roll 2: ", 10 - roll1);
            frame.AddRoll(roll2);

            if (roll1 + roll2 == 10) // spare
            {
                int bonus = GetRollInput("Bonus Roll: ", 10);
                frame.AddRoll(bonus);
            }
        }
    }
}