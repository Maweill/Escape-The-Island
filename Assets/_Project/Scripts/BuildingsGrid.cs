using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    [SerializeField]
    public Vector2Int gridSize = new Vector2Int(10, 10);

    private Building[,] _grid;
    private Building _flyingBuilding;
    private Camera _mainCamera;
    
    private void Awake()
    {
        _grid = new Building[gridSize.x, gridSize.y];
        _mainCamera = Camera.main;
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (_flyingBuilding != null)
        {
            Destroy(_flyingBuilding.gameObject);
        }
        _flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if (_flyingBuilding == null) return;
        
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (!groundPlane.Raycast(ray, out float position)) return;
        
        GetPlacementCoordinates(ray, position, out int x, out int y);
        bool isPlaceAvailable = !(IsBuildingOutOfGrid(x, y) || IsPlaceTaken(x, y));
        
        _flyingBuilding.transform.position = new Vector3(x, 0, y);
        _flyingBuilding.SetTransparent(isPlaceAvailable);

        if (!isPlaceAvailable || !Input.GetMouseButtonDown(0)) return;
        PlaceFlyingBuilding(x, y);
    }

    private static void GetPlacementCoordinates(Ray ray, float position, out int x, out int y)
    {
        Vector3 worldPosition = ray.GetPoint(position);
        x = Mathf.RoundToInt(worldPosition.x);
        y = Mathf.RoundToInt(worldPosition.z);
    }


    private bool IsBuildingOutOfGrid(int placeX, int placeY)
    {
        if (placeX < 0 || placeX > gridSize.x - _flyingBuilding.size.x) return true;
        return placeY < 0 || placeY > gridSize.y - _flyingBuilding.size.y;
    }
    
    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < _flyingBuilding.size.x; x++)
        {
            for (int y = 0; y < _flyingBuilding.size.y; y++)
            {
                if (_grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < _flyingBuilding.size.x; x++)
        {
            for (int y = 0; y < _flyingBuilding.size.y; y++)
            {
                _grid[placeX + x, placeY + y] = _flyingBuilding;
            }
        }
        
        _flyingBuilding.SetNormal();
        _flyingBuilding = null;
    }
}
