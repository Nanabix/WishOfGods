using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintDisplay : MonoBehaviour
{
    public int randNum;
    public GameObject hintDisp;
    public bool genHint = false;
    List<string> hintList = new List<string>();

    void Start()
    {
        StartCoroutine(HintTracker());
        hintList.Add("Did you know, you can walk left/ right with a and s? ");
        hintList.Add("Do not forget to breathe.");
        hintList.Add("A simple one: Jump with space.");
        hintList.Add("Yuru is a mix between a scorpion and a cat.");
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
        randNum = Random.Range(1, hintList.Count);
        Debug.Log($"Message: {hintList[randNum]}");
        //hintDisp.GetComponent<Animator>.Play("Hint");
        yield return new WaitForSeconds(9f);
        genHint = false;
    }
}
