using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictimCause : MonoBehaviour
{
    public int victimCause = 1;
    public int victimWith = 1;
    public Image victimCauseImg;
    public Image victimWithImg;


    public void selectCause_1()
    {
        victimCause = 1;
    }
    public void selectCause_2()
    {
        victimCause = 2;
    }
    public void selectCause_3()
    {
        victimCause = 3;
    }
    public void selectCause_4()
    {
        victimCause = 4;
    }
    public void selectCause_5()
    {
        victimCause = 5;
    }
    public void selectCause_6()
    {
        victimCause = 6;
    }

    public void selectWith_1()
    {
        victimWith = 1;
    }
    public void selectWith_2()
    {
        victimWith = 2;
    }
    public void selectWith_3()
    {
        victimWith = 3;
    }
    public void selectWith_4()
    {
        victimWith = 4;
    }
    public void selectWith_5()
    {
        victimWith = 5;
    }
    public void selectWith_6()
    {
        victimWith = 6;
    }

    public void Confirm()
    {
        if (victimCause == 3 && victimWith == 3)
        {
            Debug.Log("Correct answer!");
        }
        else
        {
            Debug.Log("Incorrect answer");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
