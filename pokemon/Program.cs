// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon;

using System;
using System.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using pokemon.classes.pokemons;


class Program
{

    static void Main(string[] args)
    {
        // load configuration from appsettings.json
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var myConfig = config.GetSection("MyConfig").Get<MyConfig>();
        // DIExample getConfig = new DIExample(Options.Create(myConfig));
        // Console.WriteLine(myConfig.DataDir);    

        // Console.WriteLine($"Curr dir: {config.Value.GetProjectDir()}");

        Pokemon pokemon = PokemonFactory.CreatePokemon($"{myConfig?.PokemonsDataDir}/bulbasaur.json");
        Console.WriteLine(pokemon.Name);
    }
}
