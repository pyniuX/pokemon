// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

// lacking support for json interface serialization
// https://github.com/dotnet/runtime/discussions/87545

namespace pokemon.classes.pokemons;

// using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Newtonsoft.Json;
using pokemon.utils;
using System.Text.Json;

public static class PokemonFactory
{
    private static MyConfig? config;

    public static Pokemon CreatePokemon(string filePath)
    {
        string path = Path.Combine(Utils.GetProjectDir(), PokemonFactory.config.PokemonsDataDir, filePath);
        string jsonString = File.ReadAllText(path);

        var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
        Pokemon pok = JsonConvert.DeserializeObject<Pokemon>(jsonString)!;

        pok.SetDefaultHP(pok.HP);
        pok.SetType(GetPokemonType.ByString[dict["Type"].ToString()]);
        if (dict.TryGetValue("EvolutionFile", out var value))
        {
            pok.SetEvolution(value.ToString());
        }
        return pok;
    }

    public static void SetConfig(MyConfig? config)
    {
        PokemonFactory.config = config;
    }

}