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
    private readonly MyConfig? config;
    private List<IItem> inventory;
    private List<IPokemon> pokemons;
    private Stack<State> state = new Stack<State>{};
    private Invoker invoker;

    public string? Name { get; set; }
    public int Currency { get; set; }

    public State State
    {
        get { return state.Peek(); }
        set { state.Push(value); }
    }

    public Invoker Invoker
    {
        get { return invoker; }
        set { invoker = value; }
    }

    public Player(MyConfig config)
    {
        this.config = config;
        inventory = new List<IItem>();
        pokemons = new List<IPokemon>();
        Currency = 0;
        State = new MenuState(this, config);
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

    public void PopState()
    {
        state.Pop();
    }

    public State? PreviousState()
    {
        if (state.Count > 1)
        {
            var array = state.ToArray();
            return array[1];
        }
        return null;
    }
}