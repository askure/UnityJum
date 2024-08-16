using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float weight;
    [SerializeField] bool hide;
    [SerializeField] SpriteRenderer icon;
    [SerializeField] int EnableTime;
    [SerializeField] string ItemName;

    public void Init(Sprite icon,float weight,bool hide, string ItemName,int EnableTime = 0)
    {   
        this.ItemName = ItemName;
        this.icon.sprite = icon;
        this.weight = weight;
        this.hide = hide;
        if (hide && EnableTime <= 0)
            this.EnableTime = 5; //‰Šú’l5
    }
    public float GetWeight()
    {
        return weight;
    }
    public string GetItemName() { return ItemName; }
    public int GetEnableTime() { return EnableTime; }

    public bool IsHide () { return hide; }

    public ItemController CheckEnable(float time)
    {
        return hide && EnableTime > time ? this : null; 
    }
    
}
