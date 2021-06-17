using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;

public class csh1stCalculator : MonoBehaviour
{
    int[] max = new int[5];
    public int CCTV_cnt = 5;
    float[] speed_coef = new float[3];    //기울기
    float[] speed_const = new float[3];    //속도 상수
    public GameObject[] CCTV = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        DirectoryInfo di = new DirectoryInfo(@"LearningData");
        StreamReader speed_reader = new StreamReader(di.FullName + "/" + "model1_speed_data.csv");
        //StreamReader traffic_reader = new StreamReader(di.FullName + "/" + "model1_traffic_data.csv");

        int cnt = 0;

        while (cnt < 3)  //speed 파일 읽기 시작
        {
            string data_String = speed_reader.ReadLine();

            var data_values = data_String.Split(','); //string, string타입
            speed_coef[cnt] = (float)(double.Parse(data_values[0]));
            speed_const[cnt] = (float)(double.Parse(data_values[1]));
            cnt++;
        }

        max[0] = 7292; //T1 구간 최대 교통량
        max[1] = 1504; //T2 구간 최대 교통량
        max[2] = 7123; //T3 구간 최대 교통량
        max[3] = 3000; //T4 구간 최대 교통량
        max[4] = 7500; //T5 구간 최대 교통량
        CCTV = GameObject.FindGameObjectsWithTag("CCTVData");
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

        for(int i = 0; i < 3; i++)
        {
            if(i == 0)
                CCTV[i].GetComponent<cshCCTVSliderData>().velocity =
                    Mathf.Ceil(speed_coef[i] * (CCTV[i].GetComponent<cshCCTVSliderData>().congestion / 100.0f) + speed_const[i]);
            else
                CCTV[i].GetComponent<cshCCTVData>().velocity =
                    Mathf.Ceil(speed_coef[i] * (CCTV[i].GetComponent<cshCCTVData>().congestion / 100.0f) + speed_const[i]);
        }

    }

}
