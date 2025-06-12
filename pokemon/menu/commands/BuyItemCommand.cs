// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX


namespace pokemon.menu.commands;

using pokemon.classes.items;
using pokemon.utils;

public class BuyItemCommand : ICommand
{
    private Player player;
    private IItem item;

    public BuyItemCommand(Player player, IItem item)
    {
        this.player = player;
        this.item = item;
    }

    public void Execute()
    {
        Logger.Log("COMMAND", $"Buying {item.Name}");
        try
        {
            if (player.Currency < item.Price)
            {
                throw new NoEnoughMoney();
            }
            else
            {
                player.Currency -= item.Price;
                player.AddItem(item);
                Logger.Log("COMMAND", $"Successfully bought {item.Name}");
            }
        }
        catch (NoEnoughMoney)
        {
            Logger.Log("ERROR", $"You don't have enough money to buy {item.Name}");
        }

    }
}