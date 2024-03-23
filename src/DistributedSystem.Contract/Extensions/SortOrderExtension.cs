using DistributedSystem.Contract.Enumerations;

namespace DistributedSystem.Contract.Extensions;

public static class SortOrderExtension
{
    public static SortOrder ConvertStringToSortOrder(string? sortOrder)
        => !string.IsNullOrWhiteSpace(sortOrder)
        ? sortOrder.Trim().ToUpper().Equals("ASC")
        ? SortOrder.Ascending : SortOrder.Descending : SortOrder.Descending;


    /// <summary>
    /// Format: "Id-Asc, Name-Asc, Price-Asc"
    /// </summary>
    /// <param name="sortOrder"></param>
    /// <returns></returns>
    public static IDictionary<string, SortOrder> ConvertStringToSortOrderV2(string? sortOrder)
    {
        var result = new Dictionary<string, SortOrder>();

        // Case có 2 cặp trở lên "Id-Asc, Name-Asc"
        if (!string.IsNullOrWhiteSpace(sortOrder))
        {
            if (sortOrder.Trim().Split(",").Length > 0)
            {
                foreach (var item in sortOrder.Trim().Split(","))
                {
                    if (!item.Contains("-"))
                        throw new FormatException("Sort Condition should be follow bt format: Column1-ASC,Column2-DESC,...");

                    var properties = item.Trim().Split("-");

                    var key = properties[0];
                    var value = ConvertStringToSortOrder(properties[1]);
                    //result.Add(key, value); // incorrect
                    result.TryAdd(key, value); // Nếu tồn tại => ignore
                }
            }
            // Case chỉ có 1 cặp "Id-Asc"
            else
            {
                if (!sortOrder.Contains("-"))
                    throw new FormatException("Sort Condition should be follow bt format: Column1-ASC,Column2-DESC,...");

                var property = sortOrder.Trim().Split("-");
                result.TryAdd(property[0], ConvertStringToSortOrder(property[1]));
            }
        }

        return result;
    }
}
