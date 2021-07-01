using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //
    [SerializeField] private GameObject[] cards;
    [SerializeField] private GameObject[] bFSlots;
    [SerializeField] private GameObject[] handSlots;
    //

    public int[] bfSlots = { 0, 0, 0, 0, 0 };
    private int chosenNum = 0;
    private int[] slots = { 0, 0, 0, 0, 0, 0, 0, 0 };
    private int forSlot = 0;

    GameObject card;
    GameObject bfcard;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            Draw();
            
        }

        for(int i = 0; i < 8; i++)
        {
            print("hello");
            card = GameObject.FindGameObjectWithTag("" + i);
            if(!card.GetComponent<Controller>().inHand)
            {
                slots[i] = 0;
                card.tag = "bf";
            }
            else
            {
                slots[i] = 1;
            }

            if(i < 5)
            {
                bfcard = GameObject.Find(i + "" + i);
                print(bfcard.name);
                if (!bfcard.GetComponent<Controller>().inHand)
                {
                    bfSlots[i] = 1;
                }
                else
                {
                    bfSlots[i] = 0;
                }
            }
        }

        

    }

    void Draw()
    {
        forSlot = 0;
        //print(slots[forSlot]);
        while(slots[forSlot] != 0)
        {            
            forSlot++;
            if(forSlot >= 8)
            {
                forSlot = 0;
            }
            if(slots[forSlot] == 0)
            {
                break;
            }
            
        }

        chosenNum = Random.Range(0, 0);
        var newCard = Instantiate(cards[chosenNum],handSlots[forSlot].transform.position, Quaternion.identity);
        newCard.gameObject.tag = ("" + forSlot);
        slots[forSlot] = 1;

    }

}
