// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon;

using pokemon.classes.items;
using pokemon.classes.pokemons;
using pokemon.menu.states;

public class Player
{
    private List<IItem> inventory;
    private List<IPokemon> pokemons;
    private IState? state;

    public string? Name { get; set; }
    public int Currency { get; set; }

    public Player()
    {
        inventory = new List<IItem>();
        pokemons = new List<IPokemon>();
        Currency = 0;
    }

    public IReadOnlyList<IItem> Inventory => inventory.AsReadOnly();
    public IReadOnlyList<IPokemon> Pokemons => pokemons.AsReadOnly();

    public void AddItem(IItem item)
    {
        inventory.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        inventory.Remove(item);
    }

    public void AddPokemon(IItem item)
    {
        inventory.Add(item);
    }

    public void RemovePokemon(IItem item)
    {
        inventory.Remove(item);
    }


}