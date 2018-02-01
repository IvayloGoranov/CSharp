using System;

class ActivitySelection
{
    static void Main()
    {
        var activities = new[]
        {
            new {Start = 1, Finish = 4},
            new {Start = 3, Finish = 5},
            new {Start = 0, Finish = 6},
            new {Start = 5, Finish = 7},
            new {Start = 3, Finish = 8},
            new {Start = 5, Finish = 9},
            new {Start = 6, Finish = 10},
            new {Start = 8, Finish = 11},
            new {Start = 8, Finish = 12},
            new {Start = 2, Finish = 13},
            new {Start = 12, Finish = 14},
        };

        Array.Sort(activities, (a, b) => a.Finish.CompareTo(b.Finish));

        var lastSelectedActivity = activities[0];
        Console.WriteLine(lastSelectedActivity);
        foreach (var activity in activities)
        {
            if (activity.Start >= lastSelectedActivity.Finish)
            {
                // Activities are compatible
                Console.WriteLine(activity);
                lastSelectedActivity = activity;
            }
        }
    }
}
