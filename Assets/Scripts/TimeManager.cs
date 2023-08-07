using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{

    private float time;
    private Text counter;
    private bool finished = false;
    public float minute;
    public float second;
    public string sure;
    void Start()
    {
        time = Time.time;
        counter = GetComponent<Text>();
    }
    void Update()
    {
        if (finished)
            return;
        float t = Time.time - time;
        
        string minutes = ((int)t / 60).ToString();
        minute=((int)t/60);
        float seconds = Mathf.Round(((int)t % 60));
        second=Mathf.Round(((int)t % 60));
        if (seconds < 10){
            counter.text = minutes + ":0" + seconds.ToString();
            sure=minutes + ":0" + seconds.ToString();
        }
        else if (seconds >= 10){
            counter.text = minutes + ":" + seconds.ToString();
            sure=minutes + ":" + seconds.ToString();
        }
    }
    public void Finished()
    {
        finished = true;
    }
}
