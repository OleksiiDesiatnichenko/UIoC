using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace UIoC {
  public static class AssembliesExtensions {

    #region Attributes

    public static IContainer AddFromPath(this IContainer container, string path, string searchPattern = "*.dll", bool includeSubfolders = true) {
      var files = Directory.GetFiles(path, searchPattern,
        includeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
      foreach (var file in files)
        AddFromAssembly(container, Assembly.LoadFrom(file));
      return container;
    }

    public static IContainer AddFromAssembly(this IContainer container, Assembly assembly) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      foreach (var (attribute, type) in GetTypesWithAttribute(assembly, typeof(TypeAttribute)))
        container.AddType(((TypeAttribute)attribute).ResolveType ?? type, ((TypeAttribute)attribute).ResolveName, type);
      foreach (var (attribute, type) in GetTypesWithAttribute(assembly, typeof(SingletonAttribute)))
        container.AddSingleton(((SingletonAttribute)attribute).ResolveType ?? type, ((SingletonAttribute)attribute).ResolveName, type);
      return container;
    }

    private static IEnumerable<(Attribute, Type)> GetTypesWithAttribute(Assembly assembly, Type attributeType) {
      foreach (Type type in assembly.GetTypes())
        foreach (var attributeInstance in type.GetCustomAttributes(attributeType, true))
          yield return ((Attribute)attributeInstance, type);
    }

    #endregion

    #region AllTypes

    public static IContainer AddAllTypesFromPath(this IContainer container, string path, string searchPattern = "*.dll", bool includeSubfolders = true) {
      var files = Directory.GetFiles(path, searchPattern,
        includeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
      foreach (var file in files)
        AddAllTypesFromAssembly(container, Assembly.LoadFrom(file));
      return container;
    }

    public static IContainer AddAllTypesFromAssembly(this IContainer container, Assembly assembly) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      foreach (Type type in assembly.GetTypes())
        container.AddType(type);
      return container;
    }

    #endregion
  }
}
