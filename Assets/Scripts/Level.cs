using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int level = 1;
    public int star = 0;
    public bool disable = false;

    public Level(int level, int star, bool disable)
    {
        this.level = level;
        this.star = star;
        if (level != 1)
        {
            this.disable = disable;
        }
    }

    public static Level get(int level)
    {
        Dictionary<int, Level> data = Data.Get("Level") as Dictionary<int, Level>;
        if (data.ContainsKey(level))
        {
            return data[level];
        }
        return new Level(level, 0, true);
    }

    public void save()
    {
        Dictionary<int, Level> data = Data.Get("Level") as Dictionary<int, Level>;
        data.Add(this.level, this);
        Data.Set("Level", data);
        Data.Save();
    }
}