using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Image icon;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 leftTop,rightTop,rightBottom,leftBottom;
    [SerializeField] private float top,bottom,left,right;
    
    void Start()
    {
        var Canvas = GameObject.Find("Canvas").transform.position;
        top = leftTop.y + Canvas.y;
        bottom = rightBottom.y + Canvas.y;
        left  = leftTop.x + Canvas.x;
        right = rightTop.x + Canvas.x;
    }


    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        transform.position += new Vector3(moveX* speed, moveY * speed,0);
        var posX = transform.position.x;
        var posY = transform.position.y;
        if (posX < left) 
            posX = left;
        if (posX > right)
            posX = right;
        if (posY > top) 
            posY = top;
        if(posY < bottom)
            posY = bottom;
        transform.position = new Vector3(posX, posY, 0);
        RotateIcon(moveX);
    }

    public void Init()
    {

    } 

    public void RotateIcon(float moveX)
    {      
        var y = transform.rotation.eulerAngles.y;
        if (moveX > 0)
            y = 180;
        else if (moveX != 0)
            y = 0;

        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
