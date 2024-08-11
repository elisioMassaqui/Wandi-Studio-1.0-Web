using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 150f; // Velocidade de zoom, ajuste conforme necessário

    void Update()
    {
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        // Ajusta o field of view da câmera com base no input do mouse
        Camera.main.fieldOfView += zoomInput * zoomSpeed;

        // Limita o field of view para evitar valores extremos (opcional)
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 20f, 80f);
    }
}
