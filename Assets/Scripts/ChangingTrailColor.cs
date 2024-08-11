using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingTrailColor : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    private float elapsedTime = 0.0f;
    private bool isDecreasing = false;

    public float colorChangeInterval = 3.0f; // Intervalo de tempo para mudar a cor (em segundos)
    public Color startColor = Color.blue;
    public Color endColor = Color.green;

    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        SetTrailColor(startColor, endColor);
    }

    void Update()
    {
        // Verifica se a trilha está sendo emitida
        if (trailRenderer.emitting)
        {
            // A trilha está sendo emitida, portanto, resete o tempo decorrido
            elapsedTime = 0.0f;
            isDecreasing = false;
        }
        else
        {
            // A trilha não está sendo emitida, incrementa o tempo decorrido apenas se estiver diminuindo
            if (!isDecreasing)
            {
                elapsedTime += Time.deltaTime;
                isDecreasing = true; // Define a bandeira para indicar que a trilha está diminuindo

                // Altera a cor da trilha a cada intervalo definido
                if (elapsedTime >= colorChangeInterval)
                {
                    ChangeTrailColor();
                    elapsedTime = 0.0f;
                }
            }
        }
    }

    // Função para alterar a cor da trilha
    void ChangeTrailColor()
    {
        Color tempColor = startColor;
        startColor = endColor;
        endColor = tempColor;

        SetTrailColor(startColor, endColor);
    }

    // Função para definir o gradiente de cor da trilha
    void SetTrailColor(Color start, Color end)
    {
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(start, 0f), new GradientColorKey(end, 1f) },
            trailRenderer.colorGradient.alphaKeys
        );

        trailRenderer.colorGradient = gradient;
    }
}
