// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;

using pokemon.utils;
using Microsoft.Extensions.Logging;
using pokemon.menu.commands;
public class MenuState : State
{
    private readonly MyConfig config;

    public MenuState(Player player, MyConfig config) : base(player)
    {
        this.config = config;
    }

    public override void ShowMenu()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine("1. Start Fight");
        Console.WriteLine("2. Open Inventory");
        Console.WriteLine("3. Open Shop");
        Console.WriteLine("4. Exit Game\n");
    }

    public override void HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                ToFight();
                break;
            case "2":
                ToInventory();
                break;
            case "3":
                ToShop(config);
                break;
            case "4":
                player.Invoker.SetAndExecuteCommand(new ExitCommand());
                break;
            default:
                Logger.Log("STATE", $"{Info()} | Invalid input: {input}");
                break;
        }
    }
}