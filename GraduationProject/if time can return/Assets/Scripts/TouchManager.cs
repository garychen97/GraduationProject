using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    
    private float timeHit = 0f;         //用于点击的时间间隔,每次点击时间间隔应大于0.2秒  

    void Update()
    {
        timeHit += Time.deltaTime;
        if (timeHit > 0.2f)
        {
            if (Input.GetMouseButton(0))
            {
                timeHit = 0f;
                RaycastHit2D hit;
               hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit)
                {
                    hit.collider.gameObject.SendMessage("OnTouched", SendMessageOptions.DontRequireReceiver);
                    
                }
            }
        }
    }
}
