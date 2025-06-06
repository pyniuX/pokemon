// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;


public class MyConfig
{
    public string DataDir { get; set; }
    public string PokemonsDataDir { get; set; }
    public string AttacksDataDir { get; set; }

}


public class Startup
{
    public IConfiguration Configuration { get; }

    // appsettings.json are loaded by default to IConfiguration
    public Startup(IConfiguration config)
    {
        Configuration = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // some init, is it crucial?
        services.AddMvc();

        // Add our Config object so it can be injected as IOptions<MyConfig>
        services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));
    }

}