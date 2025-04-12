using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValorUi : MonoBehaviour
{
    public Text text;
    public Text timer;
    public float valorM;
    public static float tempoRestante = 120;
    // Start is called before the first frame update
    void Start()
    {
        valorM = TriggerCPR.soma * 60;
        text.text = valorM.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {

        if(TriggerCPR.semaforoTimer)
        {
            valorM = TriggerCPR.soma * 60;

            if(valorM > 100 && valorM < 120)
                text.color = Color.green;
            else
                text.color = Color.red;

            text.text = valorM.ToString("F0");

            if (tempoRestante > 0)
            {
                if (tempoRestante <= 10)
                    timer.color = Color.red;
                else
                    timer.color = Color.white;
                tempoRestante = 120;
                tempoRestante -= TriggerCPR.elipsedTime;
            }
            else if(tempoRestante <= 0)
            {
                tempoRestante = 0;
                timer.color = Color.red;
            }
        }
        int minutes = Mathf.FloorToInt(tempoRestante / 60);
        int seconds = Mathf.FloorToInt(tempoRestante % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
