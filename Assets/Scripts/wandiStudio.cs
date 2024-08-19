using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wandiStudio : MonoBehaviour
{

    [Header("Conexão com servidor.")]
    public TextMeshProUGUI statusServer; // Texto de estado da porta.
    public Image imageConnect; // Mudar a cor da imagem de vermelho pra verde pra conectar.
    public GameObject progressConect; // Processar ao conectar a porta dentro de um IEnumerator

    [Header("Outros componentes da cena")]
    //Modo linha
    public GameObject usarLinha;
    public Toggle toggleLinha;

    [Header("Conexão com servidor")]
    public TextMeshProUGUI infoServer;
    public GameObject desativarControles;
    public bool chat;

    // Start is called before the first frame update
    void Start()
    {
        //Aceitar mensagens de ws
        chat = true;
        //Efeito carregar app
        StartCoroutine(iniciarHOME());
        //Esse aqui começa ativado pra tapar controle manual enquanto de chat começa ligado
        desativarControles.SetActive(true);
        //A linha renderizada na ultima junta enquanto objecto se move
        toggleLinha.isOn = false;
    }
    
       //O que fazer quando iniciarHOME.
    IEnumerator iniciarHOME(){
        //Inicie o progresso de conexao e inicializaão
        progressConect.SetActive(true);

        //Passe alguns segundos
        yield return new WaitForSeconds(3f);  

        progressConect.SetActive(false);     
    }

    /*
        //Se a porta estiver aberta ou não, muda de cor.
        if(serialPort.IsOpen){
            imageConnect.color = Color.green;
        }
        else if(!serialPort.IsOpen){
            imageConnect.color = Color.red;
            rotacionar = !true;
            home = !true;
        }
    */

    // Update is called once per frame
    void Update()
    {

        //Modo Linha
        if (toggleLinha.isOn)
        {
            usarLinha.SetActive(!false);
        }
        else if (!toggleLinha.isOn)
        {
            usarLinha.SetActive(!true);
        }

    }


    //Pra botão com on off do painel sistema pra alternar entre modo de controle na tela e modo chat
    public void conectarServer(){
        desativarControles.SetActive(true);
        infoServer.text = "Conexão com servidor ligada.";
        chat = true;
    }
    public void desconetarServer(){
        desativarControles.SetActive(false);
        infoServer.text = "Conexão com servidor desligada.";
        chat = false;
    }

}
