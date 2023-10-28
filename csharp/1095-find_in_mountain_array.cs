namespace csharp;

public class MountainArray
{
    private List<int> _underlying;
    private int callCount;

    public MountainArray(List<int> values)
    {
        _underlying = values;
        callCount = 0;
    }

    public int Get(int index)
    {
        callCount++;
        if (callCount == 100)
        {
            throw new Exception();
        }
        return _underlying[index];
    }

    public int Length()
    {
        return _underlying.Count;
    }
}

public class _1095_find_in_mountain_array
{
    public int FindInMountainArray(int target, MountainArray mountainArr)
    {
        // triple binary search with memoisation
        var alreadyVisited = new Dictionary<int, int>();

        // search 'top' of mountain
        var min = 0;
        var max = mountainArr.Length() - 1;
        while (min < max)
        {
            var mid = (min + max) / 2;
            if (!alreadyVisited.ContainsKey(mid))
            {
                alreadyVisited.Add(mid, mountainArr.Get(mid));
            }
            if (!alreadyVisited.ContainsKey(mid + 1))
            {
                alreadyVisited.Add(mid + 1, mountainArr.Get(mid + 1));
            }
            if (alreadyVisited[mid] < alreadyVisited[mid + 1])
            {
                min = mid + 1;
            }
            else
            {
                max = mid;
            }
        }
        var peak = min;
        min = 0;
        max = peak;
        while (min <= max)
        {
            var mid = (min + max) / 2;
            if (!alreadyVisited.ContainsKey(mid))
            {
                alreadyVisited.Add(mid, mountainArr.Get(mid));
            }
            if (alreadyVisited[mid] == target)
            {
                return mid;
            }
            if (alreadyVisited[mid] < target)
            {
                min = mid + 1;
            }
            else
            {
                max = mid - 1;
            }
        }
        min = peak + 1;
        max = mountainArr.Length() - 1;
        while (min <= max)
        {
            var mid = (min + max) / 2;
            if (!alreadyVisited.ContainsKey(mid))
            {
                alreadyVisited.Add(mid, mountainArr.Get(mid));
            }
            if (alreadyVisited[mid] == target)
            {
                return mid;
            }
            if (alreadyVisited[mid] > target)
            {
                min = mid + 1;
            }
            else
            {
                max = mid - 1;
            }
        }
        return -1;
    }
}
