using System.Collections;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

public class LevelItem : EnhancedScrollerCellView
{
    public bool disable;

    public int level;
    public int star;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void setItem(LevelItem levelItem)
    {
        this.disable = levelItem.disable;
        this.level = levelItem.level;
        this.star = levelItem.star;
    }
}
