using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    public GameObject jiaohu;

    public bool CanTouch = false;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
         
            jiaohu.SetActive(true);
            CanTouch = true;
        }
       
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {
            jiaohu.SetActive(false);
            CanTouch = false;
        }
    }
    void OnTouched()
    {
        if (CanTouch == true)
        {
            Debug.Log("该物体被选中了！");

        }
        
    }
}
