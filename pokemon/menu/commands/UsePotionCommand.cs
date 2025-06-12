// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.commands;

using pokemon.classes.items;

public class UsePotionCommand: ICommand
{
    private Player player;

    public UsePotionCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        Console.WriteLine($"{DateTime.Now} | COMMAND | Using potion");
        try
        {
            IItem item = player.Inventory.FirstOrDefault(i => i.Name == "Potion", null) ?? throw new ItemMissing();
            item.Execute(player, player.GetPokemon(0));
            player.RemoveItem(item);
        }
        catch (ItemMissing)
        {
            Console.WriteLine($"{DateTime.Now} | COMMAND | You don't have potion to use.");
        }
    }
}