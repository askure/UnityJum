using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

/// <summary>
/// ÉQÅ[ÉÄä«óùé“
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] EnemyContoller enemy;

    private List<EnemyContoller> enemys;
    private int finds;
    float time = 0;
    bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        finds = 0;
        Instantiate(player).Init(this);
        var obj =  GameObject.FindGameObjectsWithTag("Enemy");
        enemys = new();
        foreach(var o in obj)
        {
            enemys.Add(o.GetComponent<EnemyContoller>());
        }
        enemys.RemoveAll(e => e == null);
        StartCoroutine(CheckTime());
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public void CheckLooked(EnemyContoller enemy)
    {
        if(enemy.status == EnemyContoller.Status.LOOK)
        {
            enemy.ChangeStatusFind();
            finds++;
        }
    }

    
    IEnumerator CheckTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (finish)
                break;
            foreach(var e in enemys)
            {
                e.ChangeStatus(time);
            }
        }
        
    }
}
