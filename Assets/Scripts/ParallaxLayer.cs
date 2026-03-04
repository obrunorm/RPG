using UnityEngine;

[System.Serializable]
public class ParallaxLayer 
{
    [SerializeField] private Transform background;
    [SerializeField] private float parallaxMultiplier;
    [SerializeField] private float imageWidhtOffset = 10;

    private float imageFullWidth;
    private float imageHalfWidht;

    public void calculateImageWidth()
    {
        imageFullWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        imageHalfWidht = imageFullWidth / 2;
    }

    public void Move(float distanceToMove)
    {
        background.position += Vector3.right * (distanceToMove * parallaxMultiplier);
    }

    public void LoopBackground(float cameraLeftEdge, float cameraRightEdge)
    {
        float imageRightEdge = (background.position.x + imageHalfWidht) - imageWidhtOffset;
        float imageLeftEdge = (background.position.x - imageHalfWidht) + imageWidhtOffset;

        if (imageRightEdge < cameraLeftEdge)
            background.position += Vector3.right * imageFullWidth;
        else if (imageLeftEdge >cameraRightEdge)
            background.position += Vector3.right * -imageFullWidth;
    }
}
