namespace HaSe.Helpers.Methods {
    public static class PropertyCopier {
        public static TTarget CopyPropertiesFrom<TSource, TTarget>(TSource source) where TSource : class where TTarget : new() {
            var target = new TTarget();
            if (source is null) {
                return target;
            }

            foreach (var property in source.GetType().GetProperties()) {
                var sourceValue = property.GetValue(source);
                var targetProperty = typeof(TTarget).GetProperty(property.Name);
                if (targetProperty is null) {
                    continue;
                }

                if (!targetProperty.CanWrite) {
                    continue;
                }

                targetProperty.SetValue(target, sourceValue, null);
            }

            return target;
        }
    }
}
