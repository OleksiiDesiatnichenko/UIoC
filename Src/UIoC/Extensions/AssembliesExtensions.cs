using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UIoC {
  public static class AssembliesExtensions {

    #region AddFromType

    public static IContainer AddByAttribute(this IContainer container, Type type) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      type
        .GetCustomAttributes(typeof(TypeAttribute), false)
        .Cast<TypeAttribute>()
        .ToList()
        .ForEach(a => container.AddType(a.ResolveType ?? type, a.ResolveName, type));
      type
        .GetCustomAttributes(typeof(SingletonAttribute), false)
        .Cast<SingletonAttribute>()
        .ToList()
        .ForEach(a => container.AddSingleton(a.ResolveType ?? type, a.ResolveName, type));
      return container;
    }

    public static IContainer AddByAttribute<TActual>(this IContainer container) {
      return container.AddByAttribute(typeof(TActual));
    }

    #endregion

    #region AddWithAttributes

    public static IContainer AddByAttributeFromPath(this IContainer container, string path, string searchPattern = "*.dll", bool includeSubfolders = true) {
      if (path == null) throw new ArgumentNullException(nameof(path));
      var files = Directory.GetFiles(path, searchPattern, includeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
      foreach (var file in files)
        AddByAttributeFromAssembly(container, Assembly.LoadFrom(file));
      return container;
    }

    public static IContainer AddByAttributeFromAssembly(this IContainer container, Assembly assembly) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      foreach (Type type in assembly.GetTypes())
        container.AddByAttribute(type);
      return container;
    }

    #endregion

    #region AddAll

    public static IContainer AddAllFromPath(this IContainer container, string path, string searchPattern = "*.dll", bool includeSubfolders = true) {
      if (path == null) throw new ArgumentNullException(nameof(path));
      var files = Directory.GetFiles(path, searchPattern, includeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
      foreach (var file in files)
        AddAllFromAssembly(container, Assembly.LoadFrom(file));
      return container;
    }

    public static IContainer AddAllFromAssembly(this IContainer container, Assembly assembly) {
      if (container == null) throw new ArgumentNullException(nameof(container));
      foreach (Type type in assembly.GetTypes()) {
        container.AddType(type);
        container.AddByAttribute(type);
      }
      return container;
    }
    
    #endregion
  }
}
