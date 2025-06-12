// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

using pokemon.menu.commands;

namespace pokemon.menu.states;

public class MenuState(Player player) : State(player)
{
    public override void ShowMenu()
    {
        // TODO: load messages from json
        Console.WriteLine("\n1. Start Fight");
        Console.WriteLine("2. Open Inventory");
        Console.WriteLine("3. Open Shop");
        Console.WriteLine("4. Exit Game\n");
    }

    public override void HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                ToFight(this);
                break;
            case "2":
                ToInventory(this);
                break;
            case "3":
                ToShop(this);
                break;
            case "4":
                player.Invoker.SetAndExecuteCommand(new ExitCommand());
                break;
            default:
                Console.WriteLine($"{DateTime.Now} | STATE | {Info()} | Invalid input: {input}");
                break;
        }
    }
}