using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera mainCamera;
    public Vector3 startPos = new Vector3(0, 2, 0.1f);
    public Vector3 endPos;
    public float speed;

    public float screenFrameBorderPercentage = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
        Debug.Log("Distance between PixelWidth (1): " + (mainCamera.scaledPixelWidth * screenFrameBorderPercentage) + ", " + Input.mousePosition.x);
        Debug.Log("Distance between PixelWidth (2): " + (mainCamera.scaledPixelWidth - (mainCamera.scaledPixelWidth * screenFrameBorderPercentage)) + ", " + Input.mousePosition.x);

        if (startPos.x < mainCamera.transform.position.x && Input.mousePosition.x < mainCamera.scaledPixelWidth * screenFrameBorderPercentage)
        {
            mainCamera.transform.position += Vector3.left * 1 * Time.deltaTime * speed;
        }
        else if (endPos.x > mainCamera.transform.position.x && Input.mousePosition.x > mainCamera.scaledPixelWidth - (mainCamera.scaledPixelWidth * screenFrameBorderPercentage))
        {
            mainCamera.transform.position += Vector3.right * 1 * Time.deltaTime * speed;
        }
    }
}
