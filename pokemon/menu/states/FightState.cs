// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;

using pokemon.utils;

public class FightState(Player player) : State(player)
{
    public override void ShowMenu()
    {
        // TODO: load messages from json
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Open Inventory");
        Console.WriteLine("3. Run Away");
    }

    public override void HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                // attack
                break;
            case "2":
                // ToInventory();
                break;
            case "3":
                // attack
                break;
            default:
                Logger.Log("STATE", $"{Info()} | Invalid input: {input}");
                break;
        }
    }


}