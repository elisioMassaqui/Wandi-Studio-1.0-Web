using System;
using UnityEngine;
using NativeWebSocket;
using TMPro;

public class Connection : MonoBehaviour
{
    [Header("Conexão com servidor")]
    public wandiController wandicontroller;
    public TextMeshProUGUI messageText; // Referência ao componente TextMeshProUGUI
    


    [Header("Studio")]
    public wandiStudio wandistudio;

    WebSocket websocket;

    private async void Start()
    {
        websocket = new WebSocket("ws://localhost:8765");

        websocket.OnOpen += () => { Debug.Log("Connection open!"); };
        websocket.OnError += (e) => { Debug.Log("Error! " + e); };
        websocket.OnClose += (e) => { Debug.Log("Connection closed!"); };
        websocket.OnMessage += (bytes) => {
            string message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("OnMessage! " + message);
            UpdateMessageText(message);
            ChangeTextColor(message); // Altera a cor do texto baseado na mensagem
        };

        await websocket.Connect();
    }

    void Update()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
          websocket.DispatchMessageQueue();
        #endif
    }

    void UpdateMessageText(string message)
    {
        if (messageText != null)
        {
            messageText.text = message; // Atualiza o texto na tela com a mensagem recebida do Python
        }
    }

    void ChangeTextColor(string message)
    {
        if (messageText != null && wandistudio.chat == true)
        {
            Color color;
            switch (message)
            {
                case "J1Max":
                case "Hello, Unity!":
                wandicontroller.J1Max(40f);
                    color = Color.blue;
                    break;
                case "J1Min":
                case "Arduino":
                wandicontroller.J1Min(40f);
                    color = Color.blue;
                    break;

                case "J2Min":
                case "Causa-Efeito":
                wandicontroller.J2Min(40f);
                    color = Color.blue;
                    break;
                case "J2Max":
                case "SINER":
                case "Mr.Robot":
                wandicontroller.J2Max(40f);
                    color = Color.blue;
                    break;

                case "J3Min":
                wandicontroller.J3Min(40f);
                    color = Color.cyan;
                    break;
                case "J3Max":
                wandicontroller.J3Max(40f);
                    color = Color.cyan;
                    break;
                
                case "J4Min":
                wandicontroller.J4Min(40f);
                    color = Color.cyan;
                    break;
                case "J4Max":
                wandicontroller.J4Max(40f);
                    color = Color.cyan;
                    break;

                case "J5Min":
                wandicontroller.J5Min(40f);
                    color = Color.cyan;
                    break;
                case "J5Max":
                wandicontroller.J5Max(40f);
                    color = Color.cyan;
                    break; 

                default:
                    color = Color.white;
                    break;
            }
            messageText.color = color; // Altera a cor do texto
        }
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }
}
