using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class CreateItemPrehub : EditorWindow
{
    float weight = 0;
    Sprite icon;
    bool hide;
    int EnableTime = 0;
    string ItemName;
   [MenuItem("Tools/CreateItemPrehub", false, 1)]
    private static void ShowWindow()
    {
        CreateItemPrehub window = GetWindowWithRect<CreateItemPrehub>(new Rect(0, 0, 600, 400));
        window.titleContent = new GUIContent("CreateItemPrehub Window");
    }

    private void OnGUI()
    {
        ItemName = EditorGUILayout.TextField("アイテム名;",ItemName);
        weight = EditorGUILayout.FloatField("weight", weight);
        icon   = (Sprite)EditorGUILayout.ObjectField("Icon", icon, typeof(Sprite), true);
        hide = GUILayout.Toggle(hide, "HIDE?");
        EnableTime = EditorGUILayout.IntField("EnableTime(効果時間)", EnableTime);
        if (GUILayout.Button("Create Clone!"))
        {
            var item = Resources.Load<ItemController>("Prehub/Item");
            if (icon == null)
            {
                Debug.Log("画像がなにか，選択されていません．");
            }
            Instantiate(item);
            item.Init(icon,weight, hide, ItemName, EnableTime);
            item.gameObject.name = string.Format("Item({0})", ItemName);
        }
    }
}
