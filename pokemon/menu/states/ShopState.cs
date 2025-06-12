// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

using pokemon.classes.items;
using pokemon.menu.commands;
using pokemon.utils;

namespace pokemon.menu.states;

public class ShopState : State
{
    private readonly MyConfig config;
    
    public ShopState(Player player, MyConfig config) : base(player)
    {
        this.config = config;
    }

    public override void ShowMenu()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine($"Pokeball price: {config.PokeballPrice}");
        Console.WriteLine($"Potion price: {config.PotionPrice}");
        Console.WriteLine($"You got {player.Currency} of currency.");
        Console.WriteLine($"You got {player.CountPotions()} potions.");
        Console.WriteLine($"You got {player.CountPokeballs()} pokeballs.");
        Console.WriteLine("\n1. Buy Potion");
        Console.WriteLine("2. Buy Pokeball");
        Console.WriteLine("3. Exit");
    }

    public override void HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                player.Invoker.SetAndExecuteCommand(new BuyItemCommand(player, new Potion(config)));
                break;
            case "2":
                player.Invoker.SetAndExecuteCommand(new BuyItemCommand(player, new Pokeball(config)));
                break;
            case "3":
                ToPrevious();
                break;
            default:
                Logger.Log("STATE", $"{Info()} | Invalid input: {input}");
                break;
        }
    }

}