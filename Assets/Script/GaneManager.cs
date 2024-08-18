using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

/// <summary>
/// ÉQÅ[ÉÄä«óùé“
/// </summary>
public class GameManager : MonoBehaviour
{
    PlayerController player;
    private List<EnemyContoller> enemys;
    private List<ItemController> items;
    private int finds;
    float time;
    bool finish = false;
    int floorNum;
    [SerializeField] GameObject[] Floors;
    [SerializeField] int limitFind;
    [SerializeField] GameClearPanel gameClearPanel,gameOverPannel;
    Coroutine enemymove;
    TextMeshProUGUI hidetimeText;
    GameObject hideTime;
    // Start is called before the first frame update
    void Start()
    {
        finds = 0;
        floorNum = 0;    
        Setup();
        Init();
        enemymove = StartCoroutine(CheckTime());
    }

    public void Setup()
    {
        foreach (var f in Floors)
           f.SetActive(true);

        var obj = GameObject.FindGameObjectsWithTag("Enemy");
        enemys = new();
        foreach (var o in obj)
        {
            enemys.Add(o.GetComponent<EnemyContoller>());
        }
        enemys.RemoveAll(e => e == null);

        var itemobj = GameObject.FindGameObjectsWithTag("Item");

        items = new();
        foreach (var o in itemobj)
        {
            items.Add(o.GetComponent<ItemController>());
        }
        items.RemoveAll(e => e == null);
        items.RemoveAll(e => e.IsHide());
        player = GameObject.FindWithTag("player").GetComponent<PlayerController>();
        player.Init(this);

        hidetimeText = GameObject.Find("HIDE TIME (S)").GetComponent<TextMeshProUGUI>();
        hideTime = GameObject.Find("HIDE TIME");
        hidetimeText.gameObject.SetActive(false);
        this.hideTime.SetActive(false);


    }
    void Init()
    {   
        ChangeFloor();
        var posObj = GameObject.FindWithTag("PlayerStartPoint");
        var pos = posObj.transform.position;
        player.transform.position = pos;
        posObj.GetComponent<SpriteRenderer>().color = Color.clear;
        
        time = 0;
        
    }

    void ChangeFloor()
    {
        int index = 0;
        foreach (var floor in Floors)
        {
            if (index == floorNum)
                floor.SetActive(true);
            else
                floor.SetActive(false);

            index++;
        }
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
            if (finds == limitFind)
                GameOver();
        }
    }
    public void UpFloor()
    {
        if(finish)
            return;
        floorNum++;
        if (floorNum > Floors.Count())
        {
            Debug.LogWarning("éüÇÃäKÇ™Ç»Ç¢ÇÃÇ…ÅCäKíiÇ™Ç†ÇËÇ‹Ç∑ÅD");
            return;
        }
        Init();
        StartCoroutine(player.MoveStop());
            
    }

    public void DownFloor()
    {
        if (finish)
            return;
        floorNum--;
        if (floorNum < 0)
        {
            Debug.LogWarning("â∫ÇÃäKÇ™Ç»Ç¢ÇÃÇ…ÅCäKíiÇ™Ç†ÇËÇ‹Ç∑ÅD");
            return;
        }
        Init();
        StartCoroutine(player.MoveStop());
    }

    public void CheckItem(List<ItemController> playeritems)
    {   
        if(finish)
            return;
        if (items.Count == playeritems.Count)
            Clear();
        else
            Debug.Log("Ç‹Çæë´ÇËÇ»Ç¢");
    }
    public void GameOver()
    {
        finish = true;
        StopCoroutine(enemymove);
        Debug.Log("Finish");
       
        Instantiate(gameOverPannel, GameObject.Find("Canvas").transform).Init(player.GetPlayerItems());
    }

    public void Clear()
    {
        finish = true;
        StopCoroutine(enemymove);
        Debug.Log("Clear");
        Instantiate(gameClearPanel,GameObject.Find("Canvas").transform).Init(items,(int)time);
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
            int hidetime = player.ChangeStatus(time);
            if(hidetime > 0)
            {
                hidetimeText.SetText(string.Format("({0})",hidetime));
                hidetimeText.gameObject.SetActive(true);
                this.hideTime.SetActive(true);
            }
            else
            {
                hidetimeText.gameObject.SetActive(false);
                this.hideTime.SetActive(false);
            }
        }
        
    }
}
