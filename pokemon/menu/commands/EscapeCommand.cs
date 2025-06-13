// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.commands;

using Microsoft.Extensions.Logging;
using pokemon.classes.items;
using pokemon.classes.pokemons;
using pokemon.menu.states;
using pokemon.utils;

public class EscapeCommand : ICommand
{
    private readonly Random rand = new Random();
    private Player player;
    private IPokemon enemy;

    public EscapeCommand(Player player, IPokemon enemy)
    {
        this.player = player;
        this.enemy = enemy;
    }

    public void Execute()
    {
        Logger.Log("COMMAND", "Escaping.");
        if (rand.Next(0, 100) < CalculateEscapeChance())
        {
            Logger.Log("COMMAND", "Successfully escaped.");
            player.State.ToPrevious();
            return;
        }
        Logger.Log("COMMAND", "Escape failed.");
    }

    private double CalculateEscapeChance()
    {
        double value = 50;
        if (player.GetPokemon(0).HP > enemy.HP)
        {
            value +=30;
        }
        return value;
    }
}