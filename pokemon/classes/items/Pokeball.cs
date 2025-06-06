// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.items;

using pokemon.classes.pokemons;

class Pokeball : IItem
{
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

    public void Execute(Player player, IPokemon pokemon)
    {
        // TODO: catch pokemon
    }
}