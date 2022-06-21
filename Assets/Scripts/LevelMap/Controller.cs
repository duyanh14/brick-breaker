using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
{

    public Canvas Canvas;
    
    public Object[] levelScene;
    private List<LevelItem> levelItems = new List<LevelItem>();
    
    public EnhancedScroller scroller;
    public EnhancedScrollerCellView cellViewPrefab;
        
    public int numberOfCellsPerRow = 4;

    void Start()
    {
        scroller.Delegate = this;
        for (int i = 0; i < levelScene.Length; i++)
        {
            LevelItem item = new LevelItem();
            item.level = i+1;
            item.star = 3;
            item.disable = false;
            levelItems.Add(item);
        }
    }
    
    void Update()
    {
       
    }

    private void LoadData(int jump=-1)
    {
        // if ((jump == -1) || (jump > InventoryItemDatas.Count))
        // {
        //     jump = InventoryItemDatas.Count;
        // } 
        // scroller.ReloadData();
        // scroller.JumpToDataIndex(jump);
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return Mathf.CeilToInt((float) levelScene.Length / (float) numberOfCellsPerRow);
    }
    
    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return 100f;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        CellView cellView = scroller.GetCellView(cellViewPrefab) as CellView;
        
        cellView.name = "Cell " + (dataIndex * numberOfCellsPerRow).ToString() + " to " +
                        ((dataIndex * numberOfCellsPerRow) + numberOfCellsPerRow - 1).ToString();
        
        List<LevelItem> iid = cellView.SetData(ref levelItems, dataIndex * numberOfCellsPerRow);
       
        return cellView;
    }


}