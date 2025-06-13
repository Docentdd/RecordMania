test
To launch this application, you need to place an appsettings.json configuration file in your project’s root directory. The file must contain these sections:

"Logging": Specify log levels, for example: { "Default": "Information", "Microsoft.AspNetCore": "Warning" } "AllowedHosts": Set to "*" "ConnectionStrings": Provide your database connection string under "DefaultConnection" "
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_DATABASE_CONNECTION_STRING"
  }
}
```
