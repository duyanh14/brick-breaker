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
        public GameObject lineV;
        public TMP_Text level;
        public GameObject tutorial;
        public GameObject[] star;
        public GameObject disable;

        private Data data;
        
        public void SetData(Data data)
        {
            if (data != null)
            {
                this.data = data;
                
                if (data.level.level == 1)
                {
                    level.text = "";
                    tutorial.SetActive(true);
                }
                else
                {
                    level.text = data.level.level.ToString();
                    tutorial.SetActive(false);
                }

                for (int i = 0; i < star.Length; i++)
                {
                    if (i + 1 <= data.level.star)
                    {
                        continue;
                    }
                    star[i].SetActive(false);
                }

                disable.SetActive(data.level.disable);
                lineV.SetActive(data.line);
            }
        }
    }
}