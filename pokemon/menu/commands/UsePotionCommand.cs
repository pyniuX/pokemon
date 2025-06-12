// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.commands;

using Microsoft.Extensions.Logging;
using pokemon.classes.items;
using pokemon.utils;

public class UsePotionCommand: ICommand
{
    private Player player;

    public UsePotionCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        Logger.Log("COMMAND", "Using potion.");
        try
        {
            IItem item = player.Inventory.FirstOrDefault(i => i.Name == "Potion", null) ?? throw new ItemMissing();
            item.Execute(player, player.GetPokemon(0));
            player.RemoveItem(item);
            Logger.Log("COMMAND", "Successfully used potion.");
        }
        catch (ItemMissing)
        {
            Logger.Log("COMMAND", "You don't have potion to use.");
        }
    }
}