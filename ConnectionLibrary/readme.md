# About

- Provides methods to obtain database connection strings from a json file.
- See ConnectionLibrary.Preparation.Mocking for how appsettings was created.


```json
{
  "ConnectionStrings": {
    "DevelopmentConnection": "Server=DEV;Database=ocs;Integrated Security=true",
    "ProductionConnection": "Server=PROD;Database=ocs;Integrated Security=true",
    "TestConnection": "Server=.\\TEST;Database=ocs;Integrated Security=true",
    "Environment": 2
  }
}
```

Environment where members are `zero` based.

```csharp
namespace ConnectionLibrary
{
    /// <summary>
    /// Server environments
    /// </summary>
    public enum Environment
    {
        Production,
        Test,
        Development
    }
}
```

# Usage

Intialize once

```csharp
Helper.Initializer();
```

Get connection string

```csharp
Helper.ConnectionString
```


![image](assets/Versions.png)

![img](assets/core_csharp_shield.png)