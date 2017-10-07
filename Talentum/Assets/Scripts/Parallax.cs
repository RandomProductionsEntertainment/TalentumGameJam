using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    private Transform camera;
    private Transform[] layers;
    private float viewZone = 15;
    private int leftIndex;
    private int rightIndex;
    public float backgroundSize;
    [SerializeField]
    float parallaxSpeed;
    private float lastCameraX;
    // Use this for initialization
    void Start () {
        lastCameraX = Camera.main.transform.position.x;
        camera = Camera.main.transform;
        layers = new Transform[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
            layers[i] = gameObject.transform.GetChild(i);
        leftIndex = 0;
        rightIndex = layers.Length - 1;
	}
	
    private void LeftParallax()
    {
        int right = rightIndex;
        layers[rightIndex].position = Vector2.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }
    private void RightParallax()
    {
        int left = leftIndex;
        layers[leftIndex].position = Vector2.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
    // Update is called once per frame
    void Update () {
        float deltaX = camera.position.x - lastCameraX;
        transform.position = new Vector2((deltaX * parallaxSpeed)+transform.position.x,0);
        lastCameraX = camera.position.x;
        if (camera.transform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            LeftParallax();
        if (camera.transform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            RightParallax();
	}
}
