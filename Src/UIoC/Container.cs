using System;
using System.Collections.Generic;
using System.Linq;
using UIoC.Models;

namespace UIoC {
  public class Container : IContainer {
    internal Dictionary<string, BaseModel> Registrations { get; } = new Dictionary<string, BaseModel>();

    #region Add

    public IContainer AddType(Type resolveType, string resolveName, Type actualType) {
      if (actualType == null) throw new ArgumentNullException(nameof(actualType));
      Add(new TypeModel(resolveType, resolveName, actualType));
      return this;
    }

    public IContainer AddSingleton(Type resolveType, string resolveName, Type actualType) {
      if (actualType == null) throw new ArgumentNullException(nameof(actualType));
      Add(new SingletonModel(resolveType, resolveName, actualType));
      return this;
    }

    public IContainer AddInstance(Type resolveType, string resolveName, object actualInstance) {
      Add(new InstanceModel(resolveType, resolveName, actualInstance));
      return this;
    }

    public IContainer AddFactory(Type resolveType, string resolveName, Func<IContainer, Type, string, object> actualFactory) {
      if (actualFactory == null) throw new ArgumentNullException(nameof(actualFactory));
      Add(new FactoryModel(resolveType, resolveName, actualFactory));
      return this;
    }

    internal void Add(BaseModel registration) {
      Registrations[registration.ResolveKey] = registration;
    }

    #endregion

    #region Contains

    public bool Contains(Type resolveType, string resolveName) {
      return Contains(new BaseModel(resolveType, resolveName));
    }

    internal bool Contains(BaseModel registration) {
      return Registrations.ContainsKey(registration.ResolveKey);
    }

    #endregion

    #region Get

    public object Get(Type resolveType, string resolveName) {
      if (!Registrations.TryGetValue(new BaseModel(resolveType, resolveName).ResolveKey, out BaseModel registration))
        throw new ArgumentException($"Can't find registration for type={resolveType}, name={resolveName}");
      return Get(registration);
    }

    internal object Get(BaseModel registration) {
      switch (registration) {
        case TypeModel typeModel:
          return Create(typeModel.ActualType);
        case SingletonModel singletonModel:
          return singletonModel.ActualInstance ?? (singletonModel.ActualInstance = Create(singletonModel.ActualType));
        case InstanceModel instanceModel:
          return instanceModel.ActualInstance;
        case FactoryModel factoryModel:
          return factoryModel.ActualFactory(this, factoryModel.ResolveType, factoryModel.ResolveName);
      }

      throw new InvalidOperationException($"Can't process registration type {registration.GetType()}");
    }

    #endregion

    #region Create

    public object Create(Type actualType) {
      var exceptions = new List<Exception>();

      foreach (var ctor in actualType.GetConstructors())
        try {
          var parameters = ctor
            .GetParameters()
            .Select(p => p.HasDefaultValue
              ? p.DefaultValue
              : Get(p.ParameterType, (p.GetCustomAttributes(typeof(ResolveNameAttribute), false).FirstOrDefault() as ResolveNameAttribute)?.ResolveName))
            .ToArray();
          return ctor.Invoke(parameters);
        }
        catch (Exception ex) {
          exceptions.Add(ex);
        }

      throw new InvalidOperationException(
        $"Can't create an instance of type {actualType}",
        exceptions.Any() ? new AggregateException(exceptions) : null
      );
    }

    #endregion
  }
}
