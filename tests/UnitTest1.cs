// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace tests;

using pokemon.classes.pokemons;
using pokemon.classes.attacks;

public static class Var
{
    public const string DataDir = "/data";
    public const string PokemonsDataDir = "/data/pokemons";
    public const string AttacksDataDir = "/data/attacks";
}

public class UnitTest1
{
    [Theory]
    [InlineData($"{Var.PokemonsDataDir}/test_pokemon_1.json", "PokemonName", 0, 50, 1)]
    [InlineData($"{Var.PokemonsDataDir}/test_pokemon_2.json", "ImięPokemona123", 5, 100, 2.5)]
    public void PokemonFactoryTest(string filePath, string name, int level, int hp, float ap)
    {
        // When
        Pokemon pok = PokemonFactory.CreatePokemon(filePath);
        // Them
        Assert.Equal(pok.Name, name);
        Assert.Equal(pok.Level, level);
        Assert.Equal(pok.HP, hp);
        Assert.Equal(pok.AP, ap);
    }

    [Theory]
    [InlineData($"{Var.AttacksDataDir}/test_attack_1.json", "AttackName", 0)]
    [InlineData($"{Var.AttacksDataDir}/test_attack_2.json", "ImięAttack'u123óą", 100)]
    public void AttackFactoryTest(string filePath, string name, int ap)
    {
        // When
        Attack pok = AttackFactory.CreateAttack(filePath);
        // Them
        Assert.Equal(pok.Name, name);
        Assert.Equal(pok.AP, ap);
    }


}
