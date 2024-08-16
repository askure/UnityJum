using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameClearPanel : MonoBehaviour
{
    [SerializeField] Transform contentPos;
    [SerializeField] Node node;
    [SerializeField] TextMeshProUGUI clearTimeText;
    public void Init(List<ItemController> items, int clearTime = 0)
    {   if(clearTime != 0)
            clearTimeText.SetText(IntToTime(clearTime));
        foreach (var item in items)
        {
            Instantiate(node, contentPos).Init(item.GetItemName());
        }
    }
    private string IntToTime(int time)
    {
        int minute = time / 60;
        int second = time % 60;
        return String.Format("{0}:{1}", minute.ToString("00"), second.ToString("00"));
    }

    public void GoHome()
    {   
        //ÉzÅ[ÉÄâÊñ 
        Destroy(gameObject);

    }
}
