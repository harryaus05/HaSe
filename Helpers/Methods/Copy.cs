namespace HaSe.Helpers.Methods;
public static class Copy {
    public static TTo Members<TFrom, TTo>(TFrom f) where TFrom: class where TTo: new(){
        var t = new TTo();
        if (f is null) return t;
        foreach (var p in f.GetType().GetProperties()) {
            var v = p.GetValue(f);
            var pTo = typeof(TTo).GetProperty(p.Name);
            if (pTo is null) continue;
            if (!pTo.CanWrite) continue;
            if (pTo.PropertyType != p.PropertyType) continue;
            pTo.SetValue(t, v, null);
        }
        return t;
    } 
}
