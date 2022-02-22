using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Api {
  public static class Configuration
  {
    public static void Load()
    {
	    Container.ApplicationContainer.appConfiguration = Json.Load(
		    Path.Combine(
			    Environment.CurrentDirectory, "Configuration", "Application.json"));
    }
    public static void Load(string configurationName)
    {

    }

    public static void Get(params string[] keys)
    {
	    
      //Container.ApplicationContainer.appConfiguration.Get
    }
    public static string Get(string configurationName, params string[] keys)
    {
	    JsonElement config;
      
	    config = configurationName == "Application" ? Container.ApplicationContainer.appConfiguration : Container.ApplicationContainer.moduleConfiguration;

	    if (keys.Length == 1)
	    {
		    return config.GetProperty(keys[0]).ToString();
	    }
	    else
	    {
        for(var keyCounter = 0; keyCounter < keys.Length -1; keyCounter++)
        {
	        config = config.GetProperty(keys[keyCounter]);
        }

        return config.GetProperty(keys[^1]).ToString();
	    }
    }

  }
}