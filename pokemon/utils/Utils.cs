// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.utils;

public static class Utils
{
    public static string GetProjectDir()
    {
        var baseDir = AppContext.BaseDirectory;
        return Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;
    }
}