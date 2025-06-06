// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

using pokemon.classes.pokemons;

namespace pokemon.classes.items;

public interface IItem
{
    public string Name { get; }
    public int Price { get; }

    public bool Execute(Player player, IPokemon pokemon);
}