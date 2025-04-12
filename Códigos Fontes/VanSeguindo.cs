using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.UI;

public class VanSeguindo : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled;
    public Text timerTotal;
    public static float tempoTotal = 600;
    public static float tempoReal = 0;
    float tempo;
    bool semaforo = true;
    //Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (UiTutorial.ligar)
        {
            if (semaforo)
            {
                tempoReal = Time.time;
                semaforo = false;
            }

            tempo = Time.time - tempoReal;

            if (tempoTotal - tempo > 0)
            {
                timerTotal.color = Color.white;
                tempoTotal = 600;
                tempoTotal -= tempo;
            }

            if (tempoTotal - tempo <= 0)
                tempoTotal = 0;
            int minutes = Mathf.FloorToInt(tempoTotal / 60);
            int seconds = Mathf.FloorToInt(tempoTotal % 60);
            timerTotal.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (HapticFeedback.RCPCerto || Time.time > 600)
            {
                if (distanceTravelled > -65)
                {
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                }
            }
        }
    }
}
