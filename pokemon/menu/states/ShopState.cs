// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;

public class ShopState(Player player) : State(player)
{
    public override void ShowMenu()
    {
        // TODO: load messages from json
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1. Buy Potion");
        Console.WriteLine("2. Buy Pokeball");
        Console.WriteLine("3. Exit");
    }

    public override void HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                // buy potion
                break;
            case "2":
                // buy pokeball
                break;
            case "3":
                // exit
                break;
            default:
                Console.WriteLine($"{DateTime.Now} | STATE | {Info()} | Invalid input: {input}");
                break;
        }
    }

}