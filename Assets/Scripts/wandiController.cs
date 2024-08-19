using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class wandiController : MonoBehaviour
{
    public bool HOME;

    [Header("Juntas Steps/s")]
    public Transform origemJ1; //Pegar o vector escalar do objecto.
    public float destinoJ1; //Inicializar o vector imaginário do objecto.
    public float velocidadeJ1; // Velocidade de rotação.

    public Transform origemJ2;
    public float destinoJ2;
    public float velocidadeJ2;

    [Header("Juntas Graus/s")]
    public Transform origemJ3;
    public float destinoJ3;
    public float velocidadeJ3;
    public Transform origemJ4;
    public float destinoJ4;
    public float velocidadeJ4;

    public Transform origemJ5;
    public float destinoJ5;
    public float velocidadeJ5;

    public Transform origemJ6;
    public float destinoJ6;
    public float velocidadeJ6;

    [Header("HOME")]
    public Transform baseWandi;
    public float baseWandiDestino;
    public float baseWandiVelocidade;
    public Vector3 baseWandiPosition = new Vector3(1.58f, 0.52f, 0f);
    public float vectoresWandi;
    
    [Header("Angulos das Juntas Na UI")]
    public TextMeshProUGUI anguloJ1;  //Mostrar, o angulo da junta a ser movida, em tempo real na tela.
    public TextMeshProUGUI anguloJ2;
    public TextMeshProUGUI anguloJ3;
    public TextMeshProUGUI anguloJ4;
    public TextMeshProUGUI anguloJ5;

    [Header("Posição Sincronizada na UI")]
    public TextMeshProUGUI SincronizadaJ1UI;
    public TextMeshProUGUI SincronizadaJ2UI;
    public TextMeshProUGUI SincronizadaJ3UI;
    public TextMeshProUGUI SincronizadaJ4UI;
    public TextMeshProUGUI SincronizadaJ5UI;

    [Header("Valor Unitário das Juntas Na UI")]
    public TextMeshProUGUI unitJ1;  //Mostrar, o valor a ser ++ ou -- dos botoes.
    public TextMeshProUGUI unitJ2;
    public TextMeshProUGUI unitJ3;
    public TextMeshProUGUI unitJ4;
    public TextMeshProUGUI unitJ5;

    [Header("Buttton e Slider Pra Velocidade na UI")]
    public Slider sliderVelocidadeJ1;
    public Slider sliderVelocidadeJ2;
    public Slider sliderVelocidadeJ3;
    public Slider sliderVelocidadeJ4;
    public Slider sliderVelocidadeJ5;

    [Header("Mostrar Na UI Velocidade Das Juntas")]
    public TextMeshProUGUI mostrarVelocidadeJ1UI;
    public TextMeshProUGUI mostrarVelocidadeJ2UI;
    public TextMeshProUGUI mostrarVelocidadeJ3UI;
    public TextMeshProUGUI mostrarVelocidadeJ4UI;
    public TextMeshProUGUI mostrarVelocidadeJ5UI;


    // Start is called before the first frame update......
    void Start()
    {
        //Permitir mover o wandi
        HOME = true;
    }

    



    // Update is called once per frame.
    void Update()
    {
        //Limitar o valor da velocidade entre 0....e....1.
          sliderVelocidadeJ1.value = Mathf.Clamp(sliderVelocidadeJ1.value, 0.00f, 0.09f);
          sliderVelocidadeJ2.value = Mathf.Clamp(sliderVelocidadeJ2.value, 0.00f, 0.09f);
          sliderVelocidadeJ3.value = Mathf.Clamp(sliderVelocidadeJ3.value, 0.00f, 0.09f);
          sliderVelocidadeJ4.value = Mathf.Clamp(sliderVelocidadeJ4.value, 0.00f, 0.09f);
          sliderVelocidadeJ5.value = Mathf.Clamp(sliderVelocidadeJ5.value, 0.00f, 0.09f);
          baseWandiVelocidade= Mathf.Clamp(baseWandiVelocidade, 0.00f, 0.09f);
        
        //A float da velocidade vai receber o valor do slider
          velocidadeJ1 = sliderVelocidadeJ1.value;
          velocidadeJ2 = sliderVelocidadeJ2.value;
          velocidadeJ3 = sliderVelocidadeJ3.value;
          velocidadeJ4 = sliderVelocidadeJ4.value;
          velocidadeJ5 = sliderVelocidadeJ5.value;

         // Mostrar a velociade ao lado controlador slider de velocidade
          mostrarVelocidadeJ1UI.text = velocidadeJ1.ToString("F2");
          mostrarVelocidadeJ2UI.text = velocidadeJ2.ToString("F2");
          mostrarVelocidadeJ3UI.text = velocidadeJ3.ToString("F2");
          mostrarVelocidadeJ4UI.text = velocidadeJ4.ToString("F2");
          mostrarVelocidadeJ5UI.text = velocidadeJ5.ToString("F2");
          


         //O texto do angulo J da UI vai receber a string concatenada com o progresso do seu angulo.
        anguloJ1.text = "Angulo J1.Y: " + origemJ1.localRotation.y.ToString("F2");
        anguloJ2.text = "Angulo J2.Z: " + origemJ2.localRotation.z.ToString("F2");
        anguloJ3.text = "Angulo J3.Z: " + origemJ3.localRotation.z.ToString("F2");
        anguloJ4.text = "Angulo J4.Y: " + origemJ4.localRotation.z.ToString("F2");
        anguloJ5.text = "Angulo J5.Y: " + origemJ5.localRotation.y.ToString("F2");

        //As caixas de textos na ui no lado esquerdo dos buttons vão receber valor unitário aplicados nos vectores imaginarios.
        unitJ1.text = destinoJ1.ToString();
        unitJ2.text = destinoJ2.ToString();
        unitJ3.text = destinoJ3.ToString();
        unitJ4.text = destinoJ4.ToString();
        unitJ5.text = destinoJ5.ToString();


    
        //Se bool for permitivo, !false entâo rotacione;
        //A origem da junta, nesse caso o vector escalar vai receber o valor do destino da junta, nesse caso o vector imaginario com a respectiva "velocidade",  a + (a + b) * t;
        //Isso no método slerp (Liner Spherical Interpolation) da classe quaternion, e o vector imaginário será um euler da classe quaternion também.

          if(HOME)
          {
             
             //Juntas Steps/s
            origemJ1.localRotation = Quaternion.Slerp(origemJ1.localRotation, Quaternion.Euler(0, destinoJ1, 0), velocidadeJ1);
            origemJ2.localRotation = Quaternion.Slerp(origemJ2.localRotation, Quaternion.Euler(0, 0, destinoJ2), velocidadeJ2);
            //Juntas Graus/s
            origemJ3.localRotation = Quaternion.Slerp(origemJ3.localRotation, Quaternion.Euler(0, 0, destinoJ3), velocidadeJ3);
            origemJ4.localRotation = Quaternion.Slerp(origemJ4.localRotation, Quaternion.Euler(0, 0, destinoJ4), velocidadeJ4);
            origemJ5.localRotation = Quaternion.Slerp(origemJ5.localRotation, Quaternion.Euler(0, destinoJ5, 0), velocidadeJ5);
            //falta J6, mas é básico.

            //Inicialização, trato disso depois
            //baseWandi.localPosition = Vector3.Lerp(baseWandi.localPosition, baseWandiPosition, baseWandiVelocidade);
            //vectoresWandi = baseWandiPosition.y - baseWandiPosition.z;

            // Apos conecetar a porta vai sincronizar a posiçao com WR e os dados irao pra UI
            SincronizadaJ1UI.text = "Posição J1.Y: " + origemJ1.localRotation.ToString("F1");
            SincronizadaJ2UI.text = "Posição J2.Z: " + origemJ2.localRotation.ToString("F1");
            SincronizadaJ3UI.text = "Posição J3.Z: " + origemJ3.localRotation.ToString("F1");
            SincronizadaJ4UI.text = "Posição J4.Y: " + origemJ4.localRotation.ToString("F1");
            SincronizadaJ5UI.text = "Posição3 J5.Y: " + origemJ5.localRotation.ToString("F1");
          }

        //Steps e Graus.
        destinoJ1 = Mathf.Clamp(destinoJ1, -180f, 180f);   //Suposto valor inicial: 2
        destinoJ2 = Mathf.Clamp(destinoJ2, -50f, 10f);   //Suposto valor inicial: 10

        destinoJ3 = Mathf.Clamp(destinoJ3, -80f, -60f);  //Suposto valor inicial: -77
        destinoJ4 = Mathf.Clamp(destinoJ4,-64f, -46f);   //Suposto valor inicial: -54
        destinoJ5 = Mathf.Clamp(destinoJ5, -87f, 90f);   //Suposto valor inicial: 2
          
    }

    //A cada clique no button vai incrementar ou decrementar no valor do destino da junta.

    //Buttons para Steps/s
    public void J1Max(float num = 40f){
        destinoJ1 += num;
    } 
    public void J1Min(float num = 40f){
        destinoJ1 -= num;
    }
    public void J2Max(float num = 40f){
        destinoJ2 += num;
    }
    public void J2Min(float num = 40f){
        destinoJ2 -= num;
    } 

    //Buttons para Graus/s
    public void J3Max(float num = 40f){
        destinoJ3 += num;

    }
    public void J3Min(float num = 40f){
        destinoJ3 -= num;

    }
    public void J4Max(float num = 40f){
        destinoJ4 += num;

    }
    public void J4Min(float num = 40f){
        destinoJ4 -= num;

    }
    public void J5Max(float num = 40f){
        destinoJ5 += num;

    }
    public void J5Min(float num = 40f){
        destinoJ5 -= num;

    }

    public void J6Max(float num = 40f){
        destinoJ5 += num;

    }
    public void J6Min(float num = 40f){
        destinoJ5 -= num;

    }





    //Velocidade do slider pode se incrementar e decrementar aqui e pra cada funçºao pode enviar algum char no Wandi Robot pra mudar a velocidade lá também, ao mesmo tempooo
    public void velocidadeJ1Min(float vel = 0.01f){
        sliderVelocidadeJ1.value -= vel;

    }
    public void VelocidadeJ1Max(float vel = 0.01f){
        sliderVelocidadeJ1.value += vel;

    }
    public void velocidadeJ2Min(float vel = 0.01f){
        sliderVelocidadeJ2.value -= vel;

    }
    public void VelocidadeJ2Max(float vel = 0.01f){
        sliderVelocidadeJ2.value += vel;

    }
    public void velocidadeJ3Min(float vel = 0.01f){
        sliderVelocidadeJ3.value -= vel;

    }
    public void VelocidadeJ3Max(float vel = 0.01f){
        sliderVelocidadeJ3.value += vel;

    }
    public void velocidadeJ4Min(float vel = 0.01f){
        sliderVelocidadeJ4.value -= vel;

    }
    public void VelocidadeJ4Max(float vel = 0.01f){
        sliderVelocidadeJ4.value += vel;

    }
    public void velocidadeJ5Min(float vel = 0.01f){
        sliderVelocidadeJ5.value -= vel;

    }
    public void VelocidadeJ5Max(float vel = 0.01f){
        sliderVelocidadeJ5.value += vel;

    }

}
