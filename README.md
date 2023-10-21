# UIoC Container

The UIoC is a simple, lightweight inversion of control dependency injection container with basic functionality predicted behavior for the .NET Framework.

## Installation

Install UIoC using Package Manager with the `Install-Package UIoC` command or get it from the [NuGet.org](https://www.nuget.org/packages/UIoC).

## Quick Start Guide

### Create Container
```cs
var container = new Container();
```

### Types Registration

Add type with interface
```cs
// Add type
container.AddType<IMyType, MyType>();

// Get an instance of the registered type
var myType = container.Get<IMyType>();
```

Add type with resolve name 
```cs
// Add type
container.AddType<IMyType, MyTypeA>("keyA");
container.AddType<IMyType, MyTypeB>("keyB");

// Get instances of registered types by name
var myTypeA = container.Get<IMyType>("keyA");
var myTypeB = container.Get<IMyType>("keyB");
```

Add type without interface
```cs
// Add type
container.AddType<MyType>();

// Get an instance of the registered type
var myType = container.Get<MyType>();
```

### Singleton, Instance, and Factory Registration

Add singleton
```cs
// Add singleton
container.AddSingleton<IMyType, MyType>();

// Get the instance of the singleton
var myType = container.Get<IMyType>();
```

Add instance
```cs
// Add instance
container.AddInstance<IMyType>(new MyType("My Instance Type"));

// Get the instance 
var myType = container.Get<IMyType>();
```

Add factory
```cs
// Add factory
container.AddFactory<IMyType>(() => new MyType("My Factory Produced Type"));

// Get an instance 
var myType = container.Get<IMyType>();
```

### Inject into the constructor

Inject type
```cs
class MyType { ... }

class MyOuterTypeA {
  public MyOuterTypeA(MyType myType) { ... }
}

// Add types
container.AddType<MyType>();
container.AddType<MyOuterTypeA>();

// Get an instance of the MyTypeOuterA with MyType
var myOuterTypeA = container.Get<MyOuterTypeA>();
```

Inject type with resolve name 
```cs
interface IMyType { ... }

class MyTypeA : IMyType { ... }

class MyTypeB : IMyType { ... }

class MyOuterTypeB { 
  public MyOuterTypeB([Inject("keyB")]IMyType myType) { ... }
}

// Add types
container.AddType<IMyType, MyTypeA>("keyA");
container.AddType<IMyType, MyTypeB>("keyB");
container.AddType<MyOuterTypeB>();

// Get an instance of the MyTypeOuter with MyTypeB
var myOuterTypeB = container.Get<MyOuterTypeB>();
```

### Inject assembly types

Inject all types of assembly
```cs
// Inject all types from the current assembly
container.AddAllFromAssembly(Assembly.GetExecutingAssembly());
```

Specify resolve type and name for injection from assembly
```cs
interface IMyType { ... }

// Specify resolve type
[Type(typeof(IMyType))] 
class MyTypeC : IMyType { ... }

// Specify resolve type and resolve name
[Singleton(typeof(IMyType), "MySingleton")] 
class MyTypeD : IMyType { ... }

// Load only types with attributes
container.AddByAttributeFromAssembly(Assembly.GetExecutingAssembly());
```

### Create type without registration

```cs
class MyType { ... }

class MyUnregstredType { 
  public MyUnregstredType(MyType myType) { ... }
}

// Add type
container.AddType<IMyType, MyType>();

// Create type without registration with injection into the constructor
var myUnregstredType = container.Create<MyUnregstredType>();
```
