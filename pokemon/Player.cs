// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon;

using pokemon.classes.items;
using pokemon.classes.pokemons;
using pokemon.menu.commands;
using pokemon.menu.states;

public class Player
{
    private List<IItem> inventory;
    private List<IPokemon> pokemons;
    private State? state;
    private State? previousState;
    private Invoker invoker;

    public string? Name { get; set; }
    public int Currency { get; set; }

    public State? State
    {
        get { return state; }
        set { state = value; }
    }

    public State? PreviousState
    {
        get { return previousState; }
        set { previousState = value; }
    }

    public Invoker Invoker
    {
        get { return invoker; }
        set { invoker = value; }
    }

    public Player()
    {
        inventory = new List<IItem>();
        pokemons = new List<IPokemon>();
        Currency = 0;
        Currency = 0;
        state = new MenuState(this);
        invoker = new Invoker();
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

    public void AddPokemon(IPokemon pokemon)
    {
        pokemons.Add(pokemon);
    }

    public void RemovePokemon(IPokemon pokemon)
    {
        pokemons.Remove(pokemon);
    }

    public IItem GetItem(int index)
    {
        return inventory[index];
    }
     
    public IPokemon GetPokemon(int index)
    {
        return pokemons[index];
    }

    public int CountPotions()
    {
        return inventory.Count(p => p.Name == "Potion");
    }

    public int CountPokeballs()
    {
        return inventory.Count(p => p.Name == "Pokeball");
    }
}