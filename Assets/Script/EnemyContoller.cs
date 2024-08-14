using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class EnemyContoller : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]float changeTime = 5;
    int counter;
    [SerializeField] Sprite notLook, looking,find;
    [SerializeField] SpriteRenderer icon,view;
    public enum Status { 
        LOOK,/*ŠÄ‹’†*/
        UNLOOK,/*–¢ŠÄ‹’†*/
        FIND /*”­Œ©*/
    }
    public Status status;
    void Start()
    {
        icon.sprite = looking;
        counter = 1;
        view.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Init(float changeTime, Sprite notLook, Sprite looking, Sprite find)
    {
        this.notLook = notLook;
        this.looking = looking;
        this.find = find;
        this.changeTime = changeTime;
        icon.sprite = looking;
    }

    /// <summary>
    /// ŠÄ‹‚ÌON/OFF
    /// </summary>
    public void ChangeStatus(float  time)
    {
        if (time < changeTime * counter)
            return;
        switch (status)
        {

            case Status.LOOK:/* */
                status = Status.UNLOOK;
                icon.sprite = notLook;
                break; 
            case Status.UNLOOK:
                status = Status.LOOK;
                icon.sprite = looking;
                break;
        }
        counter++;
    }

    /// <summary>
    /// 
    ///Status‚ğ”­Œ©‚É•Ï‚¦‚éD
    /// </summary>
    public void ChangeStatusFind()
    {
        status = Status.FIND;
        icon.sprite = find;
    }
}
