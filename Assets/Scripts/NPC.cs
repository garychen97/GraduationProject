using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool CanTouch = false;
    public GameObject jiaohu;
    public GameObject Talk;
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
            CanTouch = false;
            jiaohu.SetActive(false);
        }
    }
    void OnTouched()
    {
        if (CanTouch == true)
        {
            Debug.Log("开始对话");
            Talk.SetActive(true);

        }

    }
}
