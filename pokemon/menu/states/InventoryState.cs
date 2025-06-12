// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;

using Microsoft.AspNetCore.Builder;
using pokemon.menu.commands;
using pokemon.utils;
public class InventoryState(Player player) : State(player)
{
    public override void ShowMenu()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine($"You got {player.CountPotions()} potions.");
        Console.WriteLine($"You got {player.CountPokeballs()} pokeballs.");
        Console.WriteLine("\n1. Use Potion");
        Console.WriteLine("2. Exit\n");
    }

    public override void HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                player.Invoker.SetAndExecuteCommand(new UsePotionCommand(player));
                break;
            case "2":
                ToPrevious();
                break;
            default:
                Logger.Log("STATE", $"{Info()} | Invalid input: {input}");
                break;
        }
    }

} 