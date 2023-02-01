 using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    public Layer[] layerPriorities = {
        Layer.Enemy,
        Layer.Walkable
    };

    [SerializeField] private float distanceToBackground = 100f;
    Camera _viewCamera;
    RaycastHit _raycastHit;
    Layer _layerHit;

    public delegate void OnLayerChange(Layer newLayer); // declare new delegate type
    public event OnLayerChange onLayerChange; // instantiate an observer set
    
    void SomeLayerChangeHandler()
    {
        print("I handle it!");
    }
    
    void Start() // TODO Awake?
    {
        _viewCamera = Camera.main;
    }

    void Update()
    {
        // Look for and return priority layer hit
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue)
            {
                _raycastHit = hit.Value;
                if (_layerHit != layer)
                {
                    _layerHit = layer;
                    onLayerChange(layer);
                }
                return;
            }
        }

        // Otherwise return background hit
        _raycastHit.distance = distanceToBackground;
        _layerHit = Layer.RaycastEndStop;
    }

    RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer; // See Unity docs for mask formation
        Ray ray = _viewCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit; // used as an out parameter
        bool hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
        if (hasHit)
        {
            return hit;
        }
        return null;
    }
    
    public RaycastHit hit
    {
        get { return _raycastHit; }
    }

    public Layer currentLayerHit
    {
        get { return _layerHit; }
    }
}
