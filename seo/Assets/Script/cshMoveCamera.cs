using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshMoveCamera : MonoBehaviour
{
    private float dist;
    public float max_x, max_y, min_x, min_y;
    public Slider slider;
    private Vector3 MouseStart;
    private Vector3 derp;

    void Start()
    {
        dist = transform.position.z;  // Distance camera is above map
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("움직임");
            MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
            MouseStart.z = transform.position.z;

        }
        else if (Input.GetMouseButton(1))
        {
            Debug.Log("움직임");
            var MouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
            MouseMove.z = transform.position.z;
            transform.position = transform.position - (MouseMove - MouseStart);
            if (transform.position.x <= min_x)
                transform.position = new Vector3(min_x, transform.position.y, dist);
            if (transform.position.x >= max_x)
                transform.position = new Vector3(max_x, transform.position.y, dist);
            if (transform.position.y <= min_y)
                transform.position = new Vector3(transform.position.x, min_y, dist);
            if (transform.position.y >= max_y)
                transform.position = new Vector3(transform.position.x, max_y, dist);
        }
    }

    public void ResetCamera()
    {
        transform.position = new Vector3(0.0f, 0.0f, dist);
        slider.value = 2.0f;
    }
}