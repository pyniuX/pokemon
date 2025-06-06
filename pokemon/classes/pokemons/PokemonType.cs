// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.pokemons;

public enum PokemonType
{
    Normal,
    Grass,
    Water,
    Fire
}

public static class GetPokemonType
{
    public static Dictionary<string, PokemonType> ByString = new()
    {
        { "Normal", PokemonType.Normal },
        { "Grass", PokemonType.Grass },
        { "Water", PokemonType.Water },
        { "Fire", PokemonType.Fire },};

    public static Dictionary<PokemonType, PokemonType> Mapping = new()
    {
        // PokemonType, StrongAgainst
        { PokemonType.Water, PokemonType.Grass },
        { PokemonType.Grass, PokemonType.Water },
        { PokemonType.Fire, PokemonType.Fire },};
}