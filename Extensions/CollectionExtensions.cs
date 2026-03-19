namespace MottSchottkyAnalizer.Core.Extensions;

public static class CollectionExtensions
{
    public static void AddRange<T>(this ICollection<T> values, IEnumerable<T> param)
    {
        foreach (T item in param)
            values.Add(item);
    }
}
