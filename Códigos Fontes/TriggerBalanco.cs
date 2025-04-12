using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerBalanco : MonoBehaviour
{
    [SerializeField]
    public XRBaseController leftControllerCPR, rightControllerCPR;
    XRGrabInteractable grabInteracble;
    HandData handData;
    // Start is called before the first frame update
    void Start()
    {
        grabInteracble = GetComponent<XRGrabInteractable>();

        grabInteracble.hoverEntered.AddListener(TurnOnBalanco);
        grabInteracble.hoverEntered.AddListener(Vibrar);
        grabInteracble.hoverExited.AddListener(TurnOffBalanco);
    }

    // Update is called once per frame
    void Update()
    {
        if(ActivateCprAnimation.balancar)
        {
            if (handData.handType == HandData.HandModelType.Right)
            {
                rightControllerCPR.SendHapticImpulse(0.7f, 0.0f);
            }
            if (handData.handType == HandData.HandModelType.Left)
            {
                leftControllerCPR.SendHapticImpulse(0.7f, 0.0f);
            }
        }
    }

    public void TurnOnBalanco(BaseInteractionEventArgs arg)
    {
        ActivateCprAnimation.balancar = true;
    }

    public void TurnOffBalanco(BaseInteractionEventArgs arg)
    {
        ActivateCprAnimation.balancar = false;
    }
    public void Vibrar(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
        }
    }
}
