using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // O objeto que a câmera orbitará
    public float distance = 10.0f; // Distância inicial da câmera ao alvo
    public float zoomSpeed = 2.0f; // Velocidade do zoom
    public float rotationSpeed = 120.0f; // Velocidade de rotação
    public float panSpeed = 0.3f; // Velocidade de movimento (pan)

    private float x = 0.0f;
    private float y = 0.0f;
    private Vector3 offset; // Deslocamento da câmera em relação ao alvo

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        offset = new Vector3(0, 0, -distance);
    }

    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(0)) // Botão esquerdo do mouse para rotação
            {
                x += Input.GetAxis("Mouse X") * rotationSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * rotationSpeed * 0.02f;

                y = Mathf.Clamp(y, -120, 120); // Limitar ângulo vertical
            }

            if (Input.GetMouseButton(1)) // Botão direito do mouse para movimento (pan)
            {
                float panX = -Input.GetAxis("Mouse X") * panSpeed;
                float panY = -Input.GetAxis("Mouse Y") * panSpeed;

                Vector3 pan = transform.right * panX + transform.up * panY;
                offset += pan;
            }

            // Zoom com a roda do mouse
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            offset += offset.normalized * scroll * zoomSpeed;
            distance = offset.magnitude;

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = target.position + rotation * offset;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
