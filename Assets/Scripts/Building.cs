using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    public Renderer mainRenderer;
    [SerializeField]
    public Vector2Int size = Vector2Int.one;

    private static readonly Color BROWN_COLOR = new Color(1f, 0.68f, 0f, 0.3f);
    private static readonly Color PURPLE_COLOR = new Color(0.88f, 0f, 1f, 0.3f);

    public void SetTransparent(bool available)
    {
        mainRenderer.material.color = available ? Color.green : Color.red;
    }

    public void SetNormal()
    {
        mainRenderer.material.color = Color.white;
    }

    private void OnDrawGizmos()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Gizmos.color = (x + y) % 2 == 0 ? PURPLE_COLOR : BROWN_COLOR;
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }
}