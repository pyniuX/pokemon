// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.items;

using pokemon.classes.pokemons;

public class Pokeball : IItem
{
    private static readonly Random random = new Random();
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

    public Pokeball()
    {
        name = "Pokeball";
        price = 10;
    }

    public bool Execute(Player player, IPokemon pokemon)
    {
        double catchChance = CalculateCatchChance(pokemon);
        if (random.Next(0, 100) < 50 + catchChance)
        {
            player.AddPokemon(pokemon);
            return true;
        }
        return false;
    }

    private double CalculateCatchChance(IPokemon pokemon)
    {
        return  (double)(0.3d * (100 - ((pokemon.HP*100)/pokemon.DefaultHP)));
    }
}