// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.items;

using pokemon.classes.pokemons;
using pokemon.utils;

public class Potion : IItem
{
    private readonly MyConfig? config;
    private string name;
    private int price;
    private int heal;

    public string Name
    {
        get { return name; }
    }

    public int Price
    {
        get { return price; }
    }

    public Potion(MyConfig config)
    {
        this.config = config;
        name = "Potion";
        price = this.config.PotionPrice;
        heal = this.config.PotionHeal;
    }

    public bool Execute(Player player, IPokemon pokemon)
    {
        pokemon.Heal(heal);
        Logger.Log("ITEM", "Successfully used potion.");
        return true;
    }
}