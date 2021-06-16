using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshZoom : MonoBehaviour
{
    public Slider slider;
    public float max;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value * 2.5f > max)
            this.GetComponent<Camera>().orthographicSize = max;
        else
            this.GetComponent<Camera>().orthographicSize = slider.value * 2.5f;
    }
}
