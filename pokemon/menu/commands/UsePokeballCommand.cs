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
        try
        {
            IItem item = player.Inventory.FirstOrDefault(i => i.Name == "Pokeball", null) ?? throw new ItemMissing();
            item.Execute(player, pokemon);
            player.RemoveItem(item);
            player.PopState();
            player.PopState();
            Logger.Log("COMMAND", "Successfully used pokeball.");
        }
        catch (ItemMissing)
        {
            Logger.Log("COMMAND", "You don't have pokeball to use.");
        }
    }
}