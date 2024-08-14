using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class CreateItemPrehub : EditorWindow
{
    float weight = 0;
    Sprite icon;
   [MenuItem("Tools/CreateItemPrehub", false, 1)]
    private static void ShowWindow()
    {
        CreateItemPrehub window = GetWindowWithRect<CreateItemPrehub>(new Rect(0, 0, 600, 400));
        window.titleContent = new GUIContent("CreateItemPrehub Window");
    }

    private void OnGUI()
    {
        weight = EditorGUILayout.FloatField("weight", weight);
        icon = (Sprite)EditorGUILayout.ObjectField("Icon", icon, typeof(Sprite), true);

        if (GUILayout.Button("Create Clone!"))
        {
            var item = Resources.Load<ItemController>("Prehub/Item");
            if (icon == null)
            {
                Debug.Log("âÊëúÇ™Ç»Ç…Ç©ÅCëIëÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅD");
            }
            Instantiate(item);
            item.Init(icon,weight);
            item.gameObject.name = "item";
        }
    }
}
