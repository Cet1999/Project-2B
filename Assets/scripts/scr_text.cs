using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_text : MonoBehaviour
{
    private int int_grade;
    private int int_score;
    private string str_grade;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int_grade = GameObject.Find("obj_manager").GetComponent<scr_manager>().hp;
        int_score = GameObject.Find("obj_manager").GetComponent<scr_manager>().score;
        if (int_grade == 5) { str_grade = "A"; }
        else if (int_grade == 4) { str_grade = "B"; }
        else if (int_grade == 3) { str_grade = "C"; }
        else if (int_grade == 2) { str_grade = "D"; }
        else if (int_grade == 1) { str_grade = "F"; }
        else { str_grade = "unknown"; }
        if (str_grade != "unknown")
        {
            GetComponent<Text>().text = string.Format("{0} requirements fulfilled and Your grade is: {1} ({2}%)", int_score, str_grade, int_grade * 20);
        } else
        {
            if (int_grade == 7)
            {
                GetComponent<Text>().text = string.Format("Let's do this project! Click to start");
            } else
            {
                GetComponent<Text>().text = string.Format("5 requirements missing! You have failed this course!");
            }
        }
    }
}
