using UnityEngine;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;
using EnhancedUI;
using System;
using TMPro;

namespace EnhancedScrollerDemos.GridSimulation
{
    public class RowCellView : MonoBehaviour
    {
        public GameObject container;
        public GameObject lineH;
        public TMP_Text level;
        public GameObject tutorial;
        public GameObject[] star;

        public void SetData(Data data)
        {
            
            if (data != null)
            {
                if (data.level == 0)
                {
                    level.text = "";
                    tutorial.SetActive(true);
                }
                else
                {
                    level.text = data.level.ToString();
                }

                for (int i = 0; i < star.Length; i++)
                {
                    if (i + 1 <= data.star)
                    {
                       continue;
                    }
                    star[i].SetActive(false);
                }
            }
        }
    }
}