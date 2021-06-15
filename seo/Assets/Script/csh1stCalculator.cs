using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class csh1stCalculator : MonoBehaviour
{
    int[] max = new int[5];
    public int CCTV_cnt = 5;
    public GameObject[] CCTV = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        max[0] = 7292; //T1 구간 최대 교통량
        max[1] = 1504; //T2 구간 최대 교통량
        max[2] = 7123; //T3 구간 최대 교통량
        max[3] = 3000; //T4 구간 최대 교통량
        max[4] = 7500; //T5 구간 최대 교통량
    }

    // Update is called once per frame
    void Update()
    {
        int[] traffic = new int[5];
        traffic[0] = (int)(CCTV[0].GetComponent<cshCCTVSliderData>().congestion / 100.0f * max[0]);
        traffic[2] = (int)(traffic[0] - (0.12 * traffic[0]));
        traffic[1] = traffic[2] - traffic[0];

        traffic[4] = (int)(traffic[2] + (0.087 * traffic[2]));
        traffic[3] = traffic[4] - traffic[2];

        for(int i = 1; i<5; i++)
        {
            if (i == 0)
                CCTV[i].GetComponent<cshCCTVSliderData>().congestion =
                    Mathf.Abs(Mathf.Ceil((float)traffic[i] / max[i] * 100.0f));
            else
                CCTV[i].GetComponent<cshCCTVData>().congestion =
                    Mathf.Abs(Mathf.Ceil((float)traffic[i] / max[i] * 100.0f));
    }

        CCTV[0].GetComponent<cshCCTVSliderData>().velocity =
            Mathf.Ceil(-40.8f * (CCTV[0].GetComponent<cshCCTVSliderData>().congestion / 100.0f) + 100.6f);
        CCTV[2].GetComponent<cshCCTVData>().velocity =
            Mathf.Ceil(-22.8f * (CCTV[2].GetComponent<cshCCTVData>().congestion / 100.0f) + 105.7f);
        CCTV[4].GetComponent<cshCCTVData>().velocity =
            Mathf.Ceil(-37.2f * (CCTV[4].GetComponent<cshCCTVData>().congestion / 100.0f) + 101.1f);

        //CCTV
    }

}
