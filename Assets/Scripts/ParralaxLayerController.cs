using UnityEngine;

public class ParralaxLayerController : MonoBehaviour
{


    [SerializeField] private Camera viewcamera;
    [SerializeField] private float cameraDeltaScalar;

    private Vector3 cameraStartPos;
    private Vector3 layerStartPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraStartPos = viewcamera.transform.position;
        layerStartPos = transform.position;

    }

    private void LateUpdate()
    {
        Vector3 CameraDelta = viewcamera.transform.position - cameraStartPos;

        float layerdeltaX = CameraDelta.x * cameraDeltaScalar;
        float layerdeltaY = CameraDelta.y * cameraDeltaScalar;

        Vector3 newLayerpos = layerStartPos + new Vector3 (layerdeltaX, layerdeltaY);

        transform.position = Vector3.Lerp(transform.position, newLayerpos, cameraDeltaScalar);
    }

}
