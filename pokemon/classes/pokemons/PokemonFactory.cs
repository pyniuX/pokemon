// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

// lacking support for json interface serialization
// https://github.com/dotnet/runtime/discussions/87545

namespace pokemon.classes.pokemons;

using pokemon.utils;
using System.Text.Json;

public static class PokemonFactory
{
    public static Pokemon CreatePokemon(string filePath)
    {
        // TODO: use path combine
        string jsonString = File.ReadAllText($"{Utils.GetProjectDir()}{filePath}");
        return JsonSerializer.Deserialize<Pokemon>(jsonString)!;
    }
}