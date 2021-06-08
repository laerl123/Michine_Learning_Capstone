using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshCCTVText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text velocity, congestion;
    public GameObject data;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(data.GetComponent<cshCCTVData>().velocity == 0)
            velocity.text = "- km/h";
        else
            velocity.text = data.GetComponent<cshCCTVData>().velocity.ToString() + "km/h";
        congestion.text = data.GetComponent<cshCCTVData>().congestion.ToString() + "%";
    }
}
