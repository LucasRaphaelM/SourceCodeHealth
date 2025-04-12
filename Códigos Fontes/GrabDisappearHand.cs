using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabDisapearHand : MonoBehaviour
{
    public GameObject[] disappear;
    public HandData rightHandPose;
    public HandData leftHandPose;

    void Start()
    {
        XRGrabInteractable grabInteracble = GetComponent<XRGrabInteractable>();

        grabInteracble.selectEntered.AddListener(SetupInv);
        grabInteracble.selectExited.AddListener(UnSetInv);

    }

    public void SetupInv(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();

            if (handData.handType == HandData.HandModelType.Right)
                rightHandPose.gameObject.SetActive(false);
            else
                leftHandPose.gameObject.SetActive(false);
            for(int i = 0; i < 3; i++)
                disappear[i].gameObject.SetActive(false);
        }
    }

    public void UnSetInv(BaseInteractionEventArgs arg)
    {
        rightHandPose.gameObject.SetActive(true);
        leftHandPose.gameObject.SetActive(true);
        for (int i = 0; i < 3; i++)
            disappear[i].gameObject.SetActive(true);
    }
}
