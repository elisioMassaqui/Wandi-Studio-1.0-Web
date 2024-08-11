using UnityEngine;

public class GridHelper : MonoBehaviour
{
    public int gridSize = 10;
    public float gridSpacing = 1.0f;
    public Material lineMaterial;

    void Start()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        for (int x = -gridSize; x <= gridSize; x++)
        {
            CreateLine(new Vector3(x * gridSpacing, 0, -gridSize * gridSpacing), 
                       new Vector3(x * gridSpacing, 0, gridSize * gridSpacing));
        }

        for (int z = -gridSize; z <= gridSize; z++)
        {
            CreateLine(new Vector3(-gridSize * gridSpacing, 0, z * gridSpacing), 
                       new Vector3(gridSize * gridSpacing, 0, z * gridSpacing));
        }
    }

void CreateLine(Vector3 start, Vector3 end)
{
    GameObject line = new GameObject("GridLine");
    line.transform.SetParent(transform);
    LineRenderer lr = line.AddComponent<LineRenderer>();
    lr.material = lineMaterial;
    lr.startWidth = 0.05f;
    lr.endWidth = 0.05f;
    lr.SetPosition(0, start);
    lr.SetPosition(1, end);

    // Adicionar BoxCollider
    BoxCollider boxCollider = line.AddComponent<BoxCollider>();
    float lineLength = Vector3.Distance(start, end);
    boxCollider.size = new Vector3(lineLength, 0.05f, 0.05f);
    Vector3 midPoint = (start + end) / 2;
    boxCollider.transform.position = midPoint;
    boxCollider.transform.rotation = Quaternion.LookRotation(end - start);
}

}
