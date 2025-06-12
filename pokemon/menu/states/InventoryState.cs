// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;

using Microsoft.AspNetCore.Builder;
using pokemon.menu.commands;

public class InventoryState(Player player) : State(player)
{
    public override void ShowMenu()
    {
        // TODO: load messages from json
        Console.WriteLine($"\nYou got {player.CountPotions()} potions.");
        Console.WriteLine($"You got {player.CountPokeballs()} pokeballs.");
        Console.WriteLine("1. Use Potion");
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
                Console.WriteLine($"{DateTime.Now} | STATE | {Info()} | Invalid input: {input}");
                break;
        }
    }

} 