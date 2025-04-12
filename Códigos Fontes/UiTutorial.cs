using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiTutorial : MonoBehaviour
{

    bool checarPulso;
    bool massagem;
    bool massagem2;
    bool reviveu;
    bool balancar;
    public static bool ligar;

    [Header("UI Tutorial")]
    public GameObject uiTutorial;
    public GameObject tutorialBotao;
    public GameObject balancarDica;
    public GameObject pulsacaoDica;
    public GameObject rcpDica;

    [Header("Textos Tutorial")]
    public TextMeshProUGUI passo1;
    public TextMeshProUGUI passo2;
    public TextMeshProUGUI passo3;
    public TextMeshProUGUI passo4;
    public TextMeshProUGUI passo5;
    public TextMeshProUGUI reviveuText;
    // Start is called before the first frame update
    void Start()
    {
        if(GameStartMenu.tutorialMode)
        {
            uiTutorial.SetActive(true);
            SetFalse();
        }
        else
        {
            uiTutorial.SetActive(false);
            tutorialBotao.SetActive(false);
            pulsacaoDica.SetActive(false);
            rcpDica.SetActive(false);
            balancarDica.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(ActivateCprAnimation.balancar || balancar)
        {
            passo1.gameObject.SetActive(false);
            passo2.gameObject.SetActive(true);
            balancarDica.SetActive(false);
            pulsacaoDica.SetActive(true);
            balancar = true;
        }

        if(HapticFeedback.vibrar || checarPulso)
        {
            passo2.gameObject.SetActive(false);
            passo3.gameObject.SetActive(true);
            pulsacaoDica.SetActive(false);
            tutorialBotao.SetActive(true);
            checarPulso = true;
        }

        if (ligar)
        {
            passo3.gameObject.SetActive(false);
            passo4.gameObject.SetActive(true);
            tutorialBotao.SetActive(false);
            rcpDica.SetActive(true);
        }

        if (TriggerCPR.pressionado || massagem)
        {
            passo4.gameObject.SetActive(false);
            passo5.gameObject.SetActive(true);
            massagem = true;
        }

        if ((HapticFeedback.vibrar && massagem) || massagem2)
        {
            passo5.gameObject.SetActive(false);
            reviveuText.gameObject.SetActive(true);
            pulsacaoDica.SetActive(false);
            rcpDica.SetActive(false);
            massagem2 = true;
        }

        if ((HapticFeedback.RCPCerto && HapticFeedback.vibrar) || reviveu)
        {
            reviveuText.color = Color.green;
            reviveu = true;
        }

        if (TriggerCPR.tentativas > 0 && !TriggerCPR.pressionado)
        {
            pulsacaoDica.SetActive(true);
            rcpDica.SetActive(false);
        }
        else if(massagem)
        {
            pulsacaoDica.SetActive(false);
            rcpDica.SetActive(true);
        }


    }

    void SetFalse()
    {
        passo2.gameObject.SetActive(false);
        passo3.gameObject.SetActive(false);
        passo4.gameObject.SetActive(false);
        passo5.gameObject.SetActive(false);
        reviveuText.gameObject.SetActive(false);
        tutorialBotao.SetActive(false);
        pulsacaoDica.SetActive(false);
        rcpDica.SetActive(false);
    }
}
