using UnityEngine;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;
using EnhancedUI;
using System;
using System.Collections.Generic;

namespace EnhancedScrollerDemos.GridSimulation
{
  
    public class CellView : EnhancedScrollerCellView
    {
        public RowCellView[] rowCellViews;

        public void SetData(ref List<Data> data, int startingIndex)
        {
            // loop through the sub cells to display their data (or disable them if they are outside the bounds of the data)
            for (var i = 0; i < rowCellViews.Length; i++)
            {
                // if the sub cell is outside the bounds of the data, we pass null to the sub cell
                rowCellViews[i].SetData(startingIndex + i < data.Count ? data[startingIndex + i] : null);
            }
        }
    }
}