using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    // Start is called before the first frame update

    float changeTime = 5;
    int counter;
    [SerializeField] Sprite notLook, looking,find;
    [SerializeField] SpriteRenderer icon,view;
    public enum Status { 
        LOOK,/*ŠÄŽ‹’†*/
        UNLOOK,/*–¢ŠÄŽ‹’†*/
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

    /// <summary>
    /// ŠÄŽ‹‚ÌON/OFF
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

    public void ChangeStatusFind()
    {
        status = Status.FIND;
        icon.sprite = find;
    }
}
