using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

enum xName { x1, x2, x3, x4};
enum yName { y1=4, y2, y3, y4 };
enum x_1_Name { x1_1=8, x2_1, x3_1, x4_1 };
enum x_2_Name { x1_2=12, x2_2, x3_2, x4_2 };

public class csh2ndCalculator : MonoBehaviour
{
    int[] max = new int[16];
    public int CCTV_cnt = 16;
    public GameObject[] CCTV = new GameObject[16];
    // Start is called before the first frame update
    void Start()
    {
        max[0] = 2011; //x1 구간 최대 교통량
        max[1] = 1053; //x2 구간 최대 교통량
        max[2] = 2293; //x3 구간 최대 교통량
        max[3] = 1588; //x4구간 최대 교통량
        max[4] = 2061; //y1 구간 최대 교통량
        max[5] = 1369; //y2 구간 최대 교통량
        max[6] = 3000; //y3 구간 최대 교통량
        max[7] = 1577; //y4 구간 최대 교통량
        max[8] = (int)(0.05 * max[0]); //x1_1 구간 최대 교통량
        max[9] = (int)(0.02 * max[1]); //x2_1 구간 최대 교통량
        max[10] = (int)(0.14 * max[2]); //x3_1 구간 최대 교통량
        max[11] = (int)(0.22 * max[3]); //x4_1 구간 최대 교통량
        max[12] = (int)(0.01 * max[0]); //x1_2 구간 최대 교통량
        max[13] = (int)(0.17 * max[1]); //x2_2 구간 최대 교통량
        max[14] = (int)(0.14* max[2]); //x3_2 구간 최대 교통량
        max[15] = (int)(0.14* max[3]); //x4_2   구간 최대 교통량

    }

    // Update is called once per frame
    void Update()
    {
        float[] traffic = new float[16];
        CCTV[0].GetComponent<cshCCTVData>().congestion = (CCTV[2].GetComponent<cshCCTVSliderData>().congestion * 0.97f);
        CCTV[1].GetComponent<cshCCTVData>().congestion = (CCTV[2].GetComponent<cshCCTVSliderData>().congestion * 0.56f);
        CCTV[3].GetComponent<cshCCTVData>().congestion = (CCTV[2].GetComponent<cshCCTVSliderData>().congestion * 0.66f);
        for (int i = 0; i < 4; i++)
        {
            if(i == 2)
                traffic[i] =
                    (int)(CCTV[i].GetComponent<cshCCTVSliderData>().congestion / 100.0f * max[i]);
            else
                traffic[i] =
                    (int)(CCTV[i].GetComponent<cshCCTVData>().congestion / 100.0f * max[i]);
        }

        traffic[8] = (traffic[0] * 0.05f);
        traffic[9] = (traffic[1] * 0.02f);
        traffic[10] = (traffic[2] * 0.14f);
        traffic[11] = (traffic[3] * 0.22f);

        traffic[12] = (traffic[0] * 0.01f);
        traffic[13] = (traffic[1] * 0.17f);
        traffic[14] = (traffic[2] * 0.14f);
        traffic[15] = (traffic[3] * 0.14f);

        traffic[4] = traffic[(int)xName.x1] + traffic[(int)x_1_Name.x4_1] - traffic[(int)x_2_Name.x2_2] + 11.21f;
        traffic[5] = traffic[(int)xName.x2] - traffic[(int)x_1_Name.x1_1] + traffic[(int)x_2_Name.x3_2] - 8.07f;
        traffic[6] = traffic[(int)xName.x3] + traffic[(int)x_1_Name.x2_1] + traffic[(int)x_2_Name.x4_2] + 0.75f;
        traffic[7] = traffic[(int)xName.x4] + traffic[(int)x_1_Name.x3_1] + traffic[(int)x_2_Name.x1_2] - 11.38f;

        for (int i = 4; i < CCTV_cnt; i++)
        {
            CCTV[i].GetComponent<cshCCTVData>().congestion =
                Mathf.Abs((float)traffic[i] / max[i] * 100.0f);
        }   //혼잡도

        CCTV[0].GetComponent<cshCCTVData>().velocity =
            Mathf.Ceil(-17.76f * (CCTV[0].GetComponent<cshCCTVData>().congestion / 100.0f) + 98.92f);
        CCTV[1].GetComponent<cshCCTVData>().velocity =
            Mathf.Ceil(-29.63f * (CCTV[1].GetComponent<cshCCTVData>().congestion / 100.0f) + 94.52f);
        CCTV[2].GetComponent<cshCCTVSliderData>().velocity =
            Mathf.Ceil(-25.71f * (CCTV[2].GetComponent<cshCCTVSliderData>().congestion / 100.0f) + 93.90f);
        CCTV[3].GetComponent<cshCCTVData>().velocity =
            Mathf.Ceil(-32.82f * (CCTV[3].GetComponent<cshCCTVData>().congestion / 100.0f) + 93.94f);
        CCTV[4].GetComponent<cshCCTVData>().velocity =
            Mathf.Ceil(-18.11f * (CCTV[4].GetComponent<cshCCTVData>().congestion / 100.0f) + 98.23f);
        CCTV[5].GetComponent<cshCCTVData>().velocity =
            Mathf.Ceil(-33.39f * (CCTV[5].GetComponent<cshCCTVData>().congestion / 100.0f) + 93.69f);
        CCTV[6].GetComponent<cshCCTVData>().velocity =
            Mathf.Ceil(-31.08f * (CCTV[6].GetComponent<cshCCTVData>().congestion / 100.0f) + 87.89f);
        CCTV[7].GetComponent<cshCCTVData>().velocity =
            Mathf.Ceil(-42.74f * (CCTV[7].GetComponent<cshCCTVData>().congestion / 100.0f) + 94.49f);

        //CCTV
    }

}
