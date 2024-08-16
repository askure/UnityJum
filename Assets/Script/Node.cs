using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public void Init(string itemName)
    {
        text.SetText(itemName);
    }
}
