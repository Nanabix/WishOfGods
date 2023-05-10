using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintDisplay : MonoBehaviour
{
    public int randNum;
    public GameObject hintDisp;
    public bool genHint = false;

    void Start()
    {
        
    }

    private void Update()
    {
        if (genHint == false)
        {
            genHint = true;
            StartCoroutine(HintTracker());
        }
    }
    IEnumerator HintTracker()
    {
        randNum = Random.Range(1, 4);
        if(randNum == 1)
        {
            hintDisp.GetComponent<Text>().text = "Did you know, you can walk left/ right with a and s? ";
            Debug.Log("Did you know, you can walk left/ right with a and s? ");
        }
        if (randNum == 2)
        {
            hintDisp.GetComponent<Text>().text = "Do not forget to breathe.";
            Debug.Log("Do not forget to breathe.");
        }
        if (randNum == 3)
        {
            hintDisp.GetComponent<Text>().text = "Yuru is a mix between a scorpion and a cat.";
            Debug.Log("Yuru is a mix between a scorpion and a cat.");
        }
        if (randNum == 4)
        {
            hintDisp.GetComponent<Text>().text = "A simple one: Jump with space";
            Debug.Log("A simple one: Jump with space");
        }
        //hintDisp.GetComponent<Animator>.Play("Hint");
        yield return new WaitForSeconds(9f);
        genHint = false;
    }
}
