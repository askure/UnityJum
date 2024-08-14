using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float weight;
    public float GetWeight()
    {
        return weight;
    }
}
