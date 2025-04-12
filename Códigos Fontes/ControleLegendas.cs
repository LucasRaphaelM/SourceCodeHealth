using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class ControleLegendas : MonoBehaviour
{
    public TextMeshProUGUI legendas;
    public GameObject canvasLegendas;

    private InputData _inputData;

    bool textoNaTela = true;
    int contador = 0;

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UiTutorial.ligar && textoNaTela)
        {
            if (contador < 1950)
                contador++;
            canvasLegendas.SetActive(true);
            if (contador >= 150 && contador <= 300)
                legendas.text = "Jogador: Oi, Preciso de ajuda!";
            if (contador >= 301 && contador <= 450)
                legendas.text = "Jogador: Eu estava caminhando aqui";
            if (contador >= 451 && contador <= 600)
                legendas.text = "Jogador: E acabei encontrando uma pessoa inconsciente!";
            if (contador >= 601 && contador <= 750)
                legendas.text = "192: Muito bem, a pessoa está respirando ou coração está batendo?";
            if (contador >= 751 && contador <= 900)
                legendas.text = "Jogador: Não está respirando, nem o coração está batendo!";
            if (contador >= 901 && contador <= 1050)
                legendas.text = "Jogador: Estou fazendo RCP nele, mas venham logo!";
            if (contador >= 1051 && contador <= 1200)
                legendas.text = "192: Pode me informar onde você está?";
            if (contador >= 1201 && contador <= 1350)
                legendas.text = "Jogador: Estou na BR 215 quilômetro 175!";
            if (contador >= 1351 && contador <= 1500)
                legendas.text = "Jogador: Estou perto também de uma placa de cidade!";
            if (contador >= 1501 && contador <= 1650)
                legendas.text = "Jogador: 10 quilômetro de Baependi e 8 quilômetro de Caxambu!";
            if (contador >= 1651 && contador <= 1800)
                legendas.text = "192: Já estou mandando ajude, aguarde 10 minutos que já estão indo!";
            if (contador >= 1949)
                textoNaTela = false;

        }
        else
            canvasLegendas.SetActive(false);
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isAPressed) )
        {
            if (isAPressed && !UiTutorial.ligar)
                UiTutorial.ligar = true;
        }
    }
}
