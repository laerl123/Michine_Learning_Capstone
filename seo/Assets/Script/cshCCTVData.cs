using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshCCTVData : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocity, congestion;
    public Slider slider;
    void Start()
    {
        velocity = congestion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        congestion = (int)(slider.value * 100.0f);
    }
}
