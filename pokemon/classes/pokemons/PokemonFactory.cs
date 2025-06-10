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
using pokemon.classes.attacks;
using Newtonsoft.Json.Linq;

public static class PokemonFactory
{
    private static MyConfig? config;

    public static Pokemon CreatePokemon(string filePath)
    {
        string path = Path.Combine(Utils.GetProjectDir(), PokemonFactory.config.PokemonsDataDir, filePath);
        string jsonString = File.ReadAllText(path);

        var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
        Console.WriteLine($"{DateTime.Now} | POKEMON | Creating pokemon from {filePath}");
        Pokemon pok = JsonConvert.DeserializeObject<Pokemon>(jsonString)!;

        pok.SetDefaultHP(pok.HP);
        // Type init
        pok.SetType(GetPokemonType.ByString[dict["Type"].ToString()]);
        // Evolution init
        if (dict.TryGetValue("EvolutionFile", out var evoFile))
        {
            pok.SetEvolution(evoFile.ToString());
        }
        // Attacks init
        if (dict.TryGetValue("AttacksFiles", out var attackFiles))
        {
            // NOTE: cannot loop through instance of <object>, or use outside of context
            if (attackFiles is JArray jArray)
            {
                foreach (string attackFile in jArray)
                {
                    Console.WriteLine($"{DateTime.Now} | POKEMON | Adding attack from: {attackFile} for pokemon: {filePath}");
                    pok.AddAttack(AttackFactory.CreateAttack(attackFile));
                }
            }
        }
        return pok;
    }

    public static void SetConfig(MyConfig? config)
    {
        PokemonFactory.config = config;
    }

}