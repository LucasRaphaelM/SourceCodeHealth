using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class TriggerCPR : MonoBehaviour
{
    [SerializeField]
    public XRBaseController leftControllerCPR, rightControllerCPR;
    private int frequencyCPR;
    private int frequencyCPRT;
    public static int tentativas = 0;
    public static float startTime;
    public static float startTimeT;
    private float timeCPR;
    private float frequencyRight;
    public static float elipsedTime = 0;
    public float restartTime;
    bool semaforo = true;
    bool semaforo2 = true;
    bool semaforo3 = true;
    bool semaforo4 = true;
    public static bool pressionado = false;
    bool restartTimebool = false;
    public static bool semaforoTimer = false;
    public HandData rightHand;
    public HandData leftHand;
    private float ruim = 0;
    private float bem = 0;

    public static float soma;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteracble = GetComponent<XRGrabInteractable>();

        grabInteracble.hoverEntered.AddListener(TurnOnCPR);
        grabInteracble.hoverExited.AddListener(TurnOffCPR);
    }

    // Update is called once per frame
    void Update()
    {
        if (pressionado)
        {
            rightControllerCPR.SendHapticImpulse(0.7f, 0.0f);
            leftControllerCPR.SendHapticImpulse(0.7f, 0.0f);
        }
            elipsedTime = Time.time - startTimeT;
        if (elipsedTime >= 120 && semaforo2)
        {
            Debug.Log(" ---> Soma dos /3: " + soma);
            Debug.Log(" ---> total batidas: " + frequencyCPRT);
            Debug.Log(" ---> tempo: " + elipsedTime);
            Debug.Log(" ---> precisão: " + ((bem)/(ruim+bem))*100 + "%");
            Debug.Log(" <----------------------------------->");
            semaforo2 = false;
            restartTime = elipsedTime;
            restartTimebool = true;
            if(soma  >= 1.666 && soma <= 2 && ((bem) / (ruim + bem)) * 100 >= 85)
            {
                tentativas++;
                if(Random.Range(1, 11) > 3 || tentativas >= 3)
                {
                    HapticFeedback.RCPCerto = true;
                    Debug.Log("[REVIVEU]");
                }
            }
        }

        if(elipsedTime - restartTime >= 3 && restartTimebool)
        {
            semaforo = true;
            semaforo3 = true;
            semaforo4 = true;
            pressionado = false;
            restartTimebool = false;
            semaforoTimer = false;
            frequencyCPR = 0;
            timeCPR = 0;
            soma = 0;
            frequencyCPRT = 0;
            bem = 0;
            ruim = 0;
        }
        /*Debug.Log("ELIPSED TIME: " + elipsedTime);
        Debug.Log("RESTAR TIME: " + restartTime);
        Debug.Log("E - R: " + (elipsedTime-restartTime));*/
    }

    public void TurnOnCPR(BaseInteractionEventArgs arg)
    {

        pressionado = true;
        if (arg.interactorObject is XRDirectInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            {
                if (handData.handType == HandData.HandModelType.Right)
                {
                    semaforoTimer = true;
                    if (frequencyCPR % 3 == 0 && frequencyCPR != 0)
                    {
                        timeCPR = Time.time - startTime;
                        frequencyRight = frequencyCPR / timeCPR;
                        if(semaforo4)
                        {
                            soma = frequencyRight;
                            semaforo4 = false;
                        }
                        soma = (soma + frequencyRight) / 2;
                        if (frequencyRight >= 1.666 && frequencyRight <= 2)
                            bem+=3;
                        else
                            ruim+=3;
                        //Debug.Log("Soma dos /3: " + soma + "multiplicado por 60: " + soma*60);
                        frequencyCPR = 0;
                        semaforo = true;
                    }
                    if (semaforo)
                    {
                        if(semaforo3)
                        {
                            startTimeT = Time.time;
                            elipsedTime = Time.time - startTimeT;
                            ValorUi.tempoRestante = 120;
                            restartTime = 0;
                            semaforo2 = true;
                            semaforo3 = false;
                        }
                        startTime = Time.time;
                        semaforo = false;
                    }
                    frequencyCPR += 1;
                    frequencyCPRT += 1;
                    ActivateCprAnimation.cpr = true;
                }
            }
        }
    }

    public void TurnOffCPR(BaseInteractionEventArgs arg)
    {
        pressionado = false;
        ActivateCprAnimation.cpr = false;
    }
}
