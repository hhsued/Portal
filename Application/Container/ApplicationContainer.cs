using System.Collections.Generic;
using System.Text.Json;

namespace Application.Container {
  public static partial class ApplicationContainer
  {
    public static Application.Collections.Misc.OperatingSystems OperatingSystem;
    
	  public static Application.Collections.Misc.OperatingSystemTypes OperatingSystemType;

	  public static JsonElement appConfiguration;

	  public static JsonElement moduleConfiguration;
  }
}