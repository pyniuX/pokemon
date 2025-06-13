// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;

using Microsoft.AspNetCore.Builder;
using pokemon.classes.pokemons;
using pokemon.menu.commands;
using pokemon.utils;

public class InventoryState(Player player, IPokemon? pokemon = null) : State(player)
{
    public override void ShowMenu()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine($"You got {player.CountPotions()} potions.");
        Console.WriteLine($"You got {player.CountPokeballs()} pokeballs.");
        Console.WriteLine("\n1. Use Potion");
        Console.WriteLine("2. Use Pokeball");
        Console.WriteLine("3. Exit\n");
    }

    public override void HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                player.Invoker.SetAndExecuteCommand(new UsePotionCommand(player));
                break;
            case "2":
                if (player.PreviousState().Info() == "FightState" && pokemon is not null)
                {
                    player.Invoker.SetAndExecuteCommand(new UsePokeballCommand(player, pokemon));
                }
                else
                {
                    Logger.Log("ERROR", "Cannot use pokeball outside a fight.");
                }
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