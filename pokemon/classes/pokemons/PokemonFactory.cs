// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

// lacking support for json interface serialization
// https://github.com/dotnet/runtime/discussions/87545

namespace pokemon.classes.pokemons;

using Microsoft.Extensions.Options;
using pokemon.utils;
using System.Text.Json;

public static class PokemonFactory
{
    private static MyConfig? config;

    public static Pokemon CreatePokemon(string filePath)
    {
        string path = Path.Combine(Utils.GetProjectDir(), PokemonFactory.config.PokemonsDataDir ,filePath);
        string jsonString = File.ReadAllText(path);
        Pokemon pok = JsonSerializer.Deserialize<Pokemon>(jsonString)!;
        pok.SetDefaultHP(pok.HP);
        return pok;
    }

    public static void SetConfig(MyConfig? config)
    {
        PokemonFactory.config = config;
    }

}