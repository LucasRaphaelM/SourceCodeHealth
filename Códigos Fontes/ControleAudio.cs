using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class ControleAudio : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip metronomo;
    public bool MetronoLigar = false;
    int contadorSemaforo = 0;
    bool semaforo = true;

    private InputData _inputData;
    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        musicSource.clip = metronomo;
    }

    // Update is called once per frame
    void Update()
    {
        if(semaforo && UiTutorial.ligar)
        {
            musicSource.Play();
            semaforo = false;
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isBPressed))
        {
            contadorSemaforo++;
            if (isBPressed)
            {
                if(contadorSemaforo > 100)
                {
                    if (MetronoLigar)
                    {
                        UiTutorial.ligar = true;
                        musicSource.Play();
                        MetronoLigar = false;
                        Debug.Log("Tocando");
                    }
                    else
                    {
                        musicSource.Pause();
                        MetronoLigar = true;
                        Debug.Log("Parou");
                    }
                    contadorSemaforo = 0;
                }
            }
        }
    }
}
