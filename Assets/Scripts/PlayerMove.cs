using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float PlayerMoveSpeed = 5;

    private DragonBones.UnityArmatureComponent unityArmature;    //UnityArmatureComponent对象

    private bool CanMove = false;
    private Vector3 MousePos;
    private Vector3 PlayerPos;
    private float PlayerScaleX = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScaleX = transform.localScale.x;
        unityArmature = GetComponent<DragonBones.UnityArmatureComponent>();//获得UnityArmatureComponent对象
        unityArmature.Play("Idel");//播放动画
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MousePos = Input.mousePosition;
            MousePos = Camera.main.ScreenToWorldPoint(MousePos);//获取鼠标相对位置        //对象的位置        
            PlayerPos =this.transform.position;
            CanMove = true;


            if (MousePos.x >= PlayerPos.x)
            {
                this.transform.localScale = new Vector3(-PlayerScaleX, transform.localScale.y, 1);
            }
            else
            {
                this.transform.localScale = new Vector3(PlayerScaleX, transform.localScale.y,1);
            }
      
        }

        if (CanMove == true)
        {
            transform.position = Vector3.MoveTowards(new Vector3 (transform.position.x,transform.position.y,0), new Vector3 (MousePos.x,transform.position.y,0), Time.deltaTime*PlayerMoveSpeed);
            if (transform.position.x == MousePos.x)
            { CanMove = false; }

        }

        
    }
}
