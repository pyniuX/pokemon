// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace tests;

public static class TestData
{
    public const string pokemonFile1 = "test_pokemon_1.json";
    public static readonly Dictionary<string, object> pokemonData1 = new()
    {
        { "Name", "PokemonName" },
        { "Level", 0 },
        { "HP", 50 },
        { "AP", 1.0f },
        { "Type", "Fire" }
    };
    public const string pokemonFile2 = "test_pokemon_2.json";
    public static readonly Dictionary<string, object> pokemonData2 = new()
    {
        { "Name", "ImięPokemona123" },
        { "Level", 5 },
        { "HP", 100 },
        { "AP", 2.5f },
        { "Type", "Normal" }
    };
    public const string attackFile1 = "test_attack_1.json";
    public static readonly Dictionary<string, object> attackData1 = new()
    {
        { "Name", "AttackName" },
        { "AP", 0 }
    };
    public const string attackFile2 = "test_attack_2.json";
    public static readonly Dictionary<string, object> attackData2 = new()
    {
        { "Name", "ImięAttack'u123óą" },
        { "AP", 100 }
    };
}