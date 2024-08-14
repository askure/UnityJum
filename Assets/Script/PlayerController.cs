using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Image icon;
    [SerializeField] private float speed;
    [SerializeField] private float top,bottom,left,right;
    GameManager gameManager;
    
    void Start()
    {
        var scaleX = transform.localScale.x;
        var scaleY = transform.localScale.y;
        var leftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
        var rightop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        bottom = leftBottom.y + scaleY / 2;
        top    = rightop.y - scaleY / 2;
        left   = leftBottom.x +  scaleX / 2;
        right  = rightop.x - scaleY / 2;
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

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "View")
        {

            var enemy = collision.gameObject.transform.parent.GetComponent<EnemyContoller>();
            gameManager.CheckLooked(enemy);

        }
    }


}
