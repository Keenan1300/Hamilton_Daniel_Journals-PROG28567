using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Camera))]
public class FollowCamera2D : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Tilemap tilemap;

    private Camera followCamera;
    private Vector3 offset;
    private Vector2 viewporthalfsize;

    //boundaries
    private float leftCameraBound;
    private float rightCameraBound; 
    private float bottomCameraBound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        followCamera = GetComponent<Camera>();
        offset = transform.position - target.position;

        CalculateCameraBounds();
    }

    private void CalculateCameraBounds()
    {
        tilemap.CompressBounds();

        float orthosize = followCamera.orthographicSize;
        viewporthalfsize = new(orthosize * followCamera.aspect, orthosize);

        Vector3Int tilemapMin = tilemap.cellBounds.min;
        Vector3Int tilemapMax = tilemap.cellBounds.max;

        leftCameraBound = tilemapMin.x + viewporthalfsize.x;
        rightCameraBound = tilemapMax.x - viewporthalfsize.x;
        bottomCameraBound = tilemapMin.y + viewporthalfsize.y;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 desiredposition = target.position + offset;
        Vector3 steppedposition = Vector3.Lerp(transform.position, desiredposition, speed * Time.deltaTime);

        steppedposition.x = Mathf.Clamp(steppedposition.x,leftCameraBound,rightCameraBound);
        steppedposition.y = Mathf.Clamp(steppedposition.y,bottomCameraBound,steppedposition.y);
        transform.position = steppedposition;
    }
}
