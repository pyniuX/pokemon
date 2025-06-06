// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace tests;

using Microsoft.Extensions.Configuration;
using pokemon.classes.pokemons;
using pokemon.classes.attacks;

public class UnitTest1
{
    public UnitTest1()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.tests.json", optional: false)
            .Build();

        var myConfig = config.GetSection("MyConfig").Get<MyConfig>();
        PokemonFactory.SetConfig(myConfig);
        AttackFactory.SetConfig(myConfig);
    }

    [Theory]
    [InlineData("test_pokemon_1.json", "PokemonName", 0, 50, 1)]
    [InlineData("test_pokemon_2.json", "ImięPokemona123", 5, 100, 2.5)]
    public void PokemonFactoryTest(string filePath, string name, int level, int hp, float ap)
    {
        // When
        IPokemon pok = PokemonFactory.CreatePokemon(filePath);
        // Them
        Assert.Equal(pok.Name, name);
        Assert.Equal(pok.Level, level);
        Assert.Equal(pok.HP, hp);
        Assert.Equal(pok.AP, ap);
    }

    [Theory]
    [InlineData("test_attack_1.json", "AttackName", 0)]
    [InlineData("test_attack_2.json", "ImięAttack'u123óą", 100)]
    public void AttackFactoryTest(string filePath, string name, int ap)
    {
        // When
        Attack pok = AttackFactory.CreateAttack(filePath);
        // Them
        Assert.Equal(pok.Name, name);
        Assert.Equal(pok.AP, ap);
    }


    [Theory]
    [InlineData("test_pokemon_1.json", "ImięPokemona123", 5, 100, 2.5)]
    [InlineData("test_pokemon_2.json", "PokemonName", 0, 50, 1)]
    public void EvolutionTest(string filePath, string name, int level, int hp, float ap)
    {
        // When
        IPokemon pok = PokemonFactory.CreatePokemon(filePath);
        IPokemon evolved = pok.Evolve();
        // Them
        Assert.Equal(evolved.Name, name);
        Assert.Equal(evolved.Level, level);
        Assert.Equal(evolved.HP, hp);
        Assert.Equal(evolved.AP, ap);
    }

    [Theory]
    [InlineData("test_pokemon_1.json", "Fire")]
    [InlineData("test_pokemon_2.json", "Normal")]
    public void PokemonTypeTest(string filePath, string pokemonType)
    {
        // When
        IPokemon pok = PokemonFactory.CreatePokemon(filePath);
        // Them
        Assert.Equal(pok.Type, GetPokemonType.ByString[pokemonType]);
    }

}
