using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateEnemyPrehub : EditorWindow
{
    int changetime;
    Sprite looking,notlook,find;
    [MenuItem("Tools/CreateEnemyPrehub", false, 1)]
    
    private static void ShowWindow()
    {
        CreateEnemyPrehub window = GetWindowWithRect<CreateEnemyPrehub>(new Rect(0, 0, 600, 400));
        window.titleContent = new GUIContent("CreatePrehub Window");
    }

    private void OnGUI()
    {
        changetime = EditorGUILayout.IntField("ChangeTime",changetime);
        looking = (Sprite)EditorGUILayout.ObjectField("looking Icon", looking, typeof(Sprite),true);
        notlook = (Sprite)EditorGUILayout.ObjectField("notlook Icon", notlook, typeof(Sprite), true);
        find    = (Sprite)EditorGUILayout.ObjectField("find Icon", find, typeof(Sprite), true);

        if(GUILayout.Button("Create Clone!"))
        {
           var enemy=  Resources.Load<EnemyContoller>("Prehub/Enemy");
           if(looking == null || notlook == null || find == null)
           {
                Debug.Log("âÊëúÇ™Ç»Ç…Ç©ÅCëIëÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅD");
           }
            Instantiate(enemy);
            enemy.Init(changetime, notlook, looking, find);
            enemy.gameObject.name = "enemy";
        }
    }
}
