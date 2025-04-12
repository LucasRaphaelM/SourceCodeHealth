using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    [SerializeField]
    public XRBaseController leftController, rightController;
    int i = 0;
    [Range(0,1)]
    public float intensidade;
    public static bool vibrar = false;
    public static bool RCPCerto = false;


    void Start()
    {
        XRGrabInteractable grabInteracble = GetComponent<XRGrabInteractable>();

        grabInteracble.hoverEntered.AddListener(TurnOnVibrar);
        grabInteracble.hoverExited.AddListener(TurnOffVibrar);
    }

    // Update is called once per frame
    void Update()
    {
        if(vibrar && RCPCerto)
        {
            SendHaptics();
        }
    }

    public void TurnOnVibrar(BaseInteractionEventArgs arg)
    {
        vibrar = true;
    }

    public void TurnOffVibrar(BaseInteractionEventArgs arg)
    {
        vibrar = false;
    }
       
    void SendHaptics()
    {
        if(i <= 15)
        {
            rightController.SendHapticImpulse(0.5f, 0.0f);
            i++;
        }
        if(i > 15 && i <= 20)
        {
            i++;
        }    
        if(i > 20 && i <= 35)
        {
            rightController.SendHapticImpulse(0.5f, 0.0f);
            i++;
        }
        if(i > 35)
        {
            i++;;
        }
        if(i > 60)
            i = 0;
    }
}