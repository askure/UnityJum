using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float weight;
    [SerializeField] SpriteRenderer icon;

    public void Init(Sprite icon,float weight)
    {
        this.icon.sprite = icon;
        this.weight = weight;
    }
    public float GetWeight()
    {
        return weight;
    }
}
