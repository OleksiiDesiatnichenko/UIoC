namespace UIoC {
  public static class SetExtensions {
    public static void Merge(this IContainer dest, IContainer src) {
      var destContainer = (Container)dest;
      var srcContainer = (Container)src;
      foreach (var srcRegistration in srcContainer.Registrations)
        destContainer.Registrations[srcRegistration.Key] = srcRegistration.Value;
    }
  }
}
