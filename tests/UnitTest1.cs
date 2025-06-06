// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace tests;

using Microsoft.Extensions.Configuration;
using pokemon;
using pokemon.classes.pokemons;
using pokemon.classes.items;
using pokemon.classes.attacks;

public class UnitTest1
{

    private MyConfig? config;

    public UnitTest1()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.tests.json", optional: false)
            .Build();

        var myConfig = config.GetSection("MyConfig").Get<MyConfig>();
        this.config = myConfig;

        PokemonFactory.SetConfig(myConfig);
        AttackFactory.SetConfig(myConfig);
    }

    public static IEnumerable<object[]> PokemonFactoryTestData =>
    new List<object[]>
    {
        new object[] {TestData.pokemonFile1, TestData.pokemonData1["Name"], TestData.pokemonData1["Level"], TestData.pokemonData1["HP"], TestData.pokemonData1["AP"] },
        new object[] {TestData.pokemonFile2, TestData.pokemonData2["Name"], TestData.pokemonData2["Level"], TestData.pokemonData2["HP"], TestData.pokemonData2["AP"] }
    };

    [Theory]
    [MemberData(nameof(PokemonFactoryTestData))]
    [MemberData(nameof(PokemonFactoryTestData))]
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

    public static IEnumerable<object[]> AttackFactoryTestData =>
    new List<object[]>
    {
        new object[] {TestData.attackFile1, TestData.attackData1["Name"], TestData.attackData1["AP"] },
        new object[] {TestData.attackFile2, TestData.attackData2["Name"], TestData.attackData2["AP"] }
    };

    [Theory]
    [MemberData(nameof(AttackFactoryTestData))]
    [MemberData(nameof(AttackFactoryTestData))]
    public void AttackFactoryTest(string filePath, string name, int ap)
    {
        // When
        Attack pok = AttackFactory.CreateAttack(filePath);
        // Them
        Assert.Equal(pok.Name, name);
        Assert.Equal(pok.AP, ap);
    }

    public static IEnumerable<object[]> EvolutionTestData =>
    new List<object[]>
    {
        new object[] {TestData.pokemonFile1, TestData.pokemonData2["Name"], TestData.pokemonData2["Level"], TestData.pokemonData2["HP"], TestData.pokemonData2["AP"] },
        new object[] {TestData.pokemonFile2, TestData.pokemonData1["Name"], TestData.pokemonData1["Level"], TestData.pokemonData1["HP"], TestData.pokemonData1["AP"] }
    };

    [Theory]
    [MemberData(nameof(EvolutionTestData))]
    [MemberData(nameof(EvolutionTestData))]
    public void EvolutionTest(string filePath, string name, int level, int hp, float ap)
    {
        // Given
        IPokemon pok = PokemonFactory.CreatePokemon(filePath);
        // When
        IPokemon evolved = pok.Evolve();
        // Them
        Assert.Equal(evolved.Name, name);
        Assert.Equal(evolved.Level, level);
        Assert.Equal(evolved.HP, hp);
        Assert.Equal(evolved.AP, ap);
    }

    public static IEnumerable<object[]> PokemonTypeTestData =>
    new List<object[]>
    {
        new object[] {TestData.pokemonFile1, TestData.pokemonData1["Type"] },
        new object[] {TestData.pokemonFile2, TestData.pokemonData2["Type"] }
    };

    [Theory]
    [MemberData(nameof(PokemonTypeTestData))]
    [MemberData(nameof(PokemonTypeTestData))]
    public void PokemonTypeTest(string filePath, string pokemonType)
    {
        // When
        IPokemon pok = PokemonFactory.CreatePokemon(filePath);
        // Them
        Assert.Equal(pok.Type, GetPokemonType.ByString[pokemonType]);
    }

    [Theory]
    [InlineData(0, 50, 50)]
    [InlineData(25, 50, 50)]
    [InlineData(50, 50, 50)]
    [InlineData(0, 20, 20)]
    [InlineData(25, 20, 45)]
    [InlineData(50, 20, 50)]
    public void HealTest(int hpBefore, int hpHealed, int hpDesired)
    {
        // Given
        IPokemon pok = PokemonFactory.CreatePokemon(TestData.pokemonFile1);
        pok.HP = hpBefore;
        // When
        pok.Heal(hpHealed);
        // Then
        Assert.Equal(pok.HP, hpDesired);
    }

    [Theory]
    [InlineData(0, 20)]
    [InlineData(25, 45)]
    [InlineData(50, 50)]
    public void PotionTest(int hpBefore, int hpDesired)
    {
        // Given
        Player player = new Player();
        IItem potion = new Potion(config);
        IPokemon pok = PokemonFactory.CreatePokemon(TestData.pokemonFile1);
        pok.HP = hpBefore;
        // When
        potion.Execute(player, pok);
        // Then
        Assert.Equal(pok.HP, hpDesired);
    }

    [Theory]
    [InlineData]
    [InlineData]
    [InlineData]
    public void PokeballTest()
    {
        // Given
        Player player = new Player();
        IItem pokeball = new Pokeball();
        IPokemon pok = PokemonFactory.CreatePokemon(TestData.pokemonFile1);
        pok.HP = pok.DefaultHP;
        // When
        bool isCaught = pokeball.Execute(player, pok);
        // Then
        if (isCaught)
        {
            Assert.Equal(player.Pokemons[0], pok);
        }
        else
        {
            Assert.Equal(player.Pokemons.Count(), 0);
        }
    }

}
