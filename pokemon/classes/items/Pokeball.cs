// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.items;

using pokemon.classes.pokemons;
using pokemon.utils;

public class Pokeball : IItem
{
    private static readonly Random random = new Random();

    private readonly MyConfig? config;
    private string name;
    private int price;

    public string Name
    {
        get { return name; }
    }

    public int Price
    {
        get { return price; }
    }

    public Pokeball(MyConfig config)
    {
        this.config = config;
        name = "Pokeball";
        price = this.config.PokeballPrice;
    }

    public bool Execute(Player player, IPokemon pokemon)
    {
        if (random.Next(0, 100) < CalculateCatchChance(pokemon))
        {
            player.AddPokemon(pokemon);
            Logger.Log("ITEM", "Successfully caught pokemon.");
            return true;
        }
        Logger.Log("ITEM", "Pokemon avoided catching.");
        return false;
    }

    private double CalculateCatchChance(IPokemon pokemon)
    {
        // the lower pokemon HP, the higher chance to catch
        return (double)(50 + (0.3d * (100 - ((pokemon.HP * 100) / pokemon.DefaultHP))));
    }
}