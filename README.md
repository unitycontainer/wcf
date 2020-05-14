[![Build status](https://ci.appveyor.com/api/projects/status/ujqcljpq388kq3dm/branch/master?svg=true)](https://ci.appveyor.com/project/unitycontainer/wcf/branch/master)
[![License](https://img.shields.io/github/license/unitycontainer/wcf.svg)](https://github.com/unitycontainer/wcf/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/Unity.wcf.svg)](https://www.nuget.org/packages/Unity.wcf)
[![NuGet](https://img.shields.io/nuget/v/Unity.wcf.svg)](https://www.nuget.org/packages/Unity.wcf)

# Unity.Wcf

Unity.Wcf is a library that allows simple Integration of Microsoft's Unity IoC container with WCF. This project includes a bespoke `InstanceProvider` that creates a child container per client connection and disposes of all registered `IDisposable` instances once the connection is terminated.

## How to use Unity.Wcf

### WAS hosted services

For WAS-based hosting, first create a WcfServiceFactory `class`. You can choose any name.
The WcfServiceFactory has to extend the `UnityServiceHostFactory` and implement the `ConfigureContainer` method.

Open the WcfServiceFactory class. Add all necessary component registrations. If you are registering `IDisposable` components that need to be created and destroyed on a per client basis (i.e. an EntityFramework DataContext), please ensure that you use the `HierarchicalLifetimeManager`:

```cs
public class WcfServiceFactory : UnityServiceHostFactory {
    protected override void ConfigureContainer(IUnityContainer container) {
        // configure container
        container
            .RegisterType<IService1, Service1>()
            .RegisterType<IRespository<Blah>, BlahRepository>()
            .RegisterType<IBlahContext, BlahContext>(new HierarchicalLifetimeManager());
    }
}
```

Right click on your svc file in the solution explorer and select View Markup. Next replace `CodeBehind="Service1.svc.cs"` with `Factory="WcfService1.WcfServiceFactory"`, where `WcfService1` is the namespace of your project. If you are using fileless activation and do not have an SVC file, change your web.config instead.

```xml
<serviceHostingEnvironment>
  <serviceActivations>
    <add factory="WcfService1.WcfServiceFactory" relativeAddress="./Service1.svc" service="WcfService1.Service1"/>
  </serviceActivations>
<serviceHostingEnvironment>
```

### Windows Service hosting

If you are hosting your WCF service within a Windows Service using a `ServiceHost`, replace the `ServiceHost` instance with the custom `Unity.Wcf.UnityServiceHost`. You will find that the `UnityServiceHost` takes in a Unity container as its first parameter but is otherwise identical to the default `ServiceHost`.

You are free to configure Unity any way you like as long as the configured container is passed into the `UnityServiceHost` correctly. As with WAS hosting, if you want Unity.WCF to dispose of `IDisposable` components, you must register those components using the `HierarchicalLifetimeManager` lifestyle.

## Code of Conduct

This project has adopted the code of conduct defined by the [Contributor Covenant](https://www.contributor-covenant.org/) to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](https://www.dotnetfoundation.org/code-of-conduct)

## Contributing

See the [Contributing guide](https://github.com/unitycontainer/unity/blob/master/CONTRIBUTING.md) for more information.

## .NET Foundation

Unity Container is a [.NET Foundation](https://dotnetfoundation.org/projects/unitycontainer) project
