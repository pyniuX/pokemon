// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon;

using System;
using System.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using pokemon.classes.pokemons;
using pokemon.classes.items;
using pokemon.menu.commands;
using pokemon.utils;

class Program
{

    static void Main(string[] args)
    {
        // load configuration from appsettings.json
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var myConfig = config.GetSection("MyConfig").Get<MyConfig>();

        PokemonFactory.SetConfig(myConfig);
        // DIExample getConfig = new DIExample(Options.Create(myConfig));
        // Console.WriteLine(myConfig.DataDir);    

        Player player = new Player(myConfig);
        Pokemon pok = PokemonFactory.CreatePokemon($"bulbasaur.json");
        pok.HP -= 15;
        IItem potion = new Potion(myConfig);
        player.AddItem(potion);
        player.AddPokemon(pok);
        player.Currency = 100;

        Invoker invoker = new Invoker();
        while (true)
        {
            player.State.ShowMenu();

            string input = Utils.TakeString("Enter your choice:");

            player.State.HandleInput(input);
            // invoker.ExecuteCommand();
        }
    }
}
