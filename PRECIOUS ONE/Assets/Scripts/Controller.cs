using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Manager manager = new Manager();
     
    //
    private Vector3 positionInHand;
    //

    public bool inHand;
    public int cardName = -55;


    void Start()
    {

    }

    private void Awake()
    {
        positionInHand = gameObject.transform.position;
        inHand = true;
        
    }

    void Update()
    {
        if(gameObject.transform.position != positionInHand && Input.GetMouseButtonUp(0))
        {
            gameObject.transform.position = positionInHand;
        }
    }

    private void OnMouseEnter()
    {
        

        if (!Input.GetMouseButtonDown(0))
        {
        gameObject.transform.localScale = new Vector2(1, 1);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, -2.6f);
        gameObject.GetComponent<Renderer>().sortingOrder = 5;
        }
        //gameObject.transform.position = positionInHand;

    }
    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector2(0.4f, 0.45f);
        gameObject.transform.position = positionInHand;
        gameObject.GetComponent<Renderer>().sortingOrder = 0;
        
    }
    private void OnMouseDrag()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(worldPosition.x, worldPosition.y,0);
        gameObject.transform.localScale = new Vector2(0.4f, 0.45f);
        gameObject.GetComponent<Renderer>().sortingOrder = 0;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "pbf" && Input.GetMouseButtonUp(0) && inHand && manager.bfSlots[int.Parse(collision.name) / 11 - 1] != 1)
        {
            positionInHand = collision.transform.position;
            inHand = false;
            cardName = int.Parse(collision.name);
            gameObject.name = collision.name;
        }
    }
    
}
