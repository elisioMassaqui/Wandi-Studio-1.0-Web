using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wandiStudio : MonoBehaviour
{
    [Header("HOME")]
    public wandiController wandicontroller;
    

    [Header("Conexão com servidor Flask.")]
    public TextMeshProUGUI statusServer; // Texto de estado da porta.
    public Image imageConnect; // Mudar a cor da imagem de vermelho pra verde pra conectar.
    public GameObject progressConect; // Processar ao conectar a porta dentro de um IEnumerator

    [Header("Outros componentes da cena")]
    //Exibe uma mensagem no console com o nome do objeto clicado
    public TMP_Text nomeObjecto;
    //Modo linha
    public GameObject usarLinha;
    public Toggle toggleLinha;

    [Header("Conexão com servidor")]
    public TextMeshProUGUI statusServerText;
    public TextMeshProUGUI infoServer;
    public int somar;
    public bool enableConnection = false;  // Booleano para ativar/desativar conexões
    public GameObject ativarControles;

    // Start is called before the first frame update
    void Start()
    {
        ativarControles.SetActive(true);
        //A linha renderizada na ultima junta enquanto objecto se move
        toggleLinha.isOn = false;

        //Nao incicie o progresso de conection ao iniciar o app, apenas após conectar e rotacionar for igual a True
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


          //Nome do objecto clicado pelo mouse
         // Verifica se o botão do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            // Lança um raio a partir da posição do mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verifica se o raio atingiu um objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Obtém o GameObject atingido pelo raio
                GameObject clickedObject = hit.collider.gameObject;

                  // Atualiza o texto na UI com o nome do objeto clicado
                if (nomeObjecto != null)
                {
                    nomeObjecto.text = "wandi.Objecto : " + clickedObject.name;
                }

                // Exibe uma mensagem no console com o nome do objeto clicado
                Debug.Log("wandi.Objecto : " + clickedObject.name);
            }
        }

    }

    //Funções usado no button "ligar desligar" bonitinhos do Modern UI
    public void ligarHOME(){
        wandicontroller.HOME = true;
        StartCoroutine(iniciarHOME());
    }
    
        //O que fazer quando iniciarHOME.
    IEnumerator iniciarHOME(){
        //Inicie o progresso de conexºao
        progressConect.SetActive(true);

        //Passe alguns segundos
        yield return new WaitForSeconds(5f);  

        progressConect.SetActive(false);     
    }
    
    public void desligarHOME(){
        wandicontroller.HOME = false;
    }


        public void conectarServer(){
        enableConnection = true;
        ativarControles.SetActive(false);
        infoServer.text = "Connection to Flask is enable.";
        wandicontroller.HOME = true;
    }
    public void desconetarServer(){
        enableConnection = false;
        ativarControles.SetActive(true);
        infoServer.text = "Connection to Flask is disabled.";
        wandicontroller.HOME = false;
    }

}
