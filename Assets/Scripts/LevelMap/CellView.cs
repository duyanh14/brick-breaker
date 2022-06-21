using UnityEngine;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;
using EnhancedUI;
using System;
using System.Collections.Generic;

public class CellView : EnhancedScrollerCellView
{
    public LevelItem[] rowCellViews;

    public List<LevelItem> SetData(ref List<LevelItem> data, int startingIndex)
    {
        List<LevelItem> list = new List<LevelItem>();
        for (var i = 0; i < rowCellViews.Length; i++)
        {
            if (startingIndex + i >= data.Count)
            {
                continue;
            }
            rowCellViews[i].setItem(data[startingIndex + i]);
            list.Add(rowCellViews[i]);
        }
        return list;
    }
}