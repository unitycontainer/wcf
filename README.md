[![Build status](https://ci.appveyor.com/api/projects/status/ujqcljpq388kq3dm/branch/master?svg=true)](https://ci.appveyor.com/project/unitycontainer/wcf/branch/master)

# Unity.Wcf

Unity.Wcf is a library that allows simple Integration of Microsoft's Unity IoC container with WCF. This project includes a bespoke InstanceProvider that creates a child container per client connection and disposes of all registered IDisposable instances once the connection is terminated.

## Changes
See [Changelog](CHANGELOG.md)

## License
[The MIT License (MIT)](LICENSE)
