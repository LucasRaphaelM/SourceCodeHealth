using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateCprAnimation : MonoBehaviour
{
    private Animator animCpr;
    public static bool cpr = false;
    public static bool balancar = false;
    void Start()
    {
        animCpr = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (cpr)
            animCpr.SetBool("CPRATIVADO", true);
        else
            animCpr.SetBool("CPRATIVADO", false);
        if (balancar)
            animCpr.SetBool("BALANCARATIVADO", true);
        else
            animCpr.SetBool("BALANCARATIVADO", false);
    }
}