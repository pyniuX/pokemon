// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.commands;

using Microsoft.Extensions.Logging;
using pokemon.classes.items;
using pokemon.utils;
using pokemon.classes.pokemons;

public class UsePokeballCommand: ICommand
{
    private Player player;
    private IPokemon pokemon;

    public UsePokeballCommand(Player player, IPokemon pokemon)
    {
        this.player = player;
        this.pokemon = pokemon;
    }

    public void Execute()
    {
        Logger.Log("COMMAND", "Using pokeball.");
        // try
        // {
        //     IItem item = player.Inventory.FirstOrDefault(i => i.Name == "Potion", null) ?? throw new ItemMissing();
        //     item.Execute(player, player.GetPokemon(0));
        //     player.RemoveItem(item);
        //     Logger.Log("COMMAND", "Successfully used potion.");
        // }
        // catch (ItemMissing)
        // {
        //     Logger.Log("COMMAND", "You don't have potion to use.");
        // }
    }
}