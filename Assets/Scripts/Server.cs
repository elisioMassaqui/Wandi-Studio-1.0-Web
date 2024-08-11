using System;
using UnityEngine;
using NativeWebSocket;
using TMPro;

public class Connection : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Referência ao componente TextMeshProUGUI
    public wandiController wandicontroller;

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
        if (messageText != null)
        {
            Color color;
            switch (message)
            {
                case "Hello, Unity!":
                wandicontroller.J1Max(40f);
                    color = Color.green;
                    break;
                case "Message 1":
                wandicontroller.J1Min(40f);
                    color = Color.red;
                    break;
                case "Message 2":
                wandicontroller.J2Min(40f);
                    color = Color.blue;
                    break;
                case "Message 3":
                wandicontroller.J2Max(40f);
                    color = Color.yellow;
                    break;
                case "Another Message":
                wandicontroller.J2Max(40f);
                    color = Color.magenta;
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
