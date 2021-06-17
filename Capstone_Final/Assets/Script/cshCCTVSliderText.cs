using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshCCTVSliderText : MonoBehaviour
{
    public Text velocity, congestion;
    public GameObject data;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (data.GetComponent<cshCCTVSliderData>().velocity == 0)
            velocity.text = "- km/h";
        else
            velocity.text = data.GetComponent<cshCCTVSliderData>().velocity.ToString() + "km/h";
        congestion.text = string.Format("{0:N2}", data.GetComponent<cshCCTVSliderData>().congestion) + "%";
    }
}
