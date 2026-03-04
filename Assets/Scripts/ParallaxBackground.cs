using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Camera mainCamera;
    private float lastCameraPositionX;
    private float cameraHalfWidht;    

    [SerializeField] private ParallaxLayer[] backgroundLayers;

    private void Awake()
    {
        mainCamera = Camera.main;
        cameraHalfWidht =mainCamera.orthographicSize * mainCamera.aspect;
        calculateImageLenght();
    }

    private void FixedUpdate()
    {
        float currentCameraPositionX = mainCamera.transform.position.x;
        float distanceToMove = currentCameraPositionX - lastCameraPositionX;
        lastCameraPositionX = currentCameraPositionX;

        float cameraLeftEdge = currentCameraPositionX - cameraHalfWidht;
        float cameraRightEdge = currentCameraPositionX + cameraHalfWidht;

        foreach (ParallaxLayer layer in backgroundLayers)
        {
            layer.Move(distanceToMove);
            layer.LoopBackground(cameraLeftEdge, cameraRightEdge);
        }
    }

    private void calculateImageLenght()
    {
        foreach(ParallaxLayer layer in backgroundLayers)
            layer.calculateImageWidth();
    }
    
}
