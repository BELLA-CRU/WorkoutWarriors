﻿< Project Sdk = "Microsoft.NET.Sdk" >

  < PropertyGroup >
    < TargetFramework > net6.0 </ TargetFramework >
    < Nullable > enable </ Nullable >

    < IsPackable > false </ IsPackable >
  </ PropertyGroup >

  < ItemGroup >
    < PackageReference Include = "FakeItEasy" Version = "7.3.1" />
    < PackageReference Include = "FluentAssertions" Version = "6.6.0" />
    < PackageReference Include = "Microsoft.EntityFrameworkCore.InMemory" Version = "6.0.3" />
    < PackageReference Include = "Microsoft.NET.Test.Sdk" Version = "16.11.0" />
    < PackageReference Include = "xunit" Version = "2.4.1" />
    < PackageReference Include = "xunit.runner.visualstudio" Version = "2.4.3" >
      < IncludeAssets > runtime; build; native; contentfiles; analyzers; buildtransitive </ IncludeAssets >
      < PrivateAssets > all </ PrivateAssets >
    </ PackageReference >
    < PackageReference Include = "coverlet.collector" Version = "3.1.0" >
      < IncludeAssets > runtime; build; native; contentfiles; analyzers; buildtransitive </ IncludeAssets >
      < PrivateAssets > all </ PrivateAssets >
    </ PackageReference >
  </ ItemGroup >

  < ItemGroup >
    < ProjectReference Include = "..\WorkoutWarriorsWebApp\WorkoutWarriorsWebApp.csproj" />
  </ ItemGroup >

</ Project >

