// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;

using pokemon.classes.pokemons;
using pokemon.menu.commands;
using pokemon.utils;

public class FightState: State
{
    private IPokemon enemy;

    public FightState(Player player): base(player)
    {
        enemy = GenerateEnemy();
    }

    public override void ShowMenu()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine($"Fighting {enemy.Name}, HP: {enemy.HP}/{enemy.DefaultHP}");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Open Inventory");
        Console.WriteLine("3. Escape");
    }

    public override void HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                // attack
                break;
            case "2":
                ToInventory(enemy);
                break;
            case "3":
                player.Invoker.SetAndExecuteCommand(new EscapeCommand(player, enemy));
                break;
            default:
                Logger.Log("STATE", $"{Info()} | Invalid input: {input}");
                break;
        }
    }

    private IPokemon GenerateEnemy()
    {
        return PokemonFactory.CreatePokemon("caterpie.json");
    }


}