using TMPro;
using UnityEngine;

public class nomeObjecto : MonoBehaviour
{
    public TMP_Text nameObject;
    void Update()
    {
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
                if (nameObject != null)
                {
                    nameObject.text = "wandi.Objecto : " + clickedObject.name;
                }

                // Exibe uma mensagem no console com o nome do objeto clicado
                Debug.Log("wandi.Objecto : " + clickedObject.name);
            }
        }
    }
}
