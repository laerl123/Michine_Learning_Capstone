using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;

enum xName { x1, x2, x3, x4};
enum yName { y1=4, y2, y3, y4 };
enum x_1_Name { x1_1=8, x2_1, x3_1, x4_1 };
enum x_2_Name { x1_2=12, x2_2, x3_2, x4_2 };

public class csh2ndCalculator : MonoBehaviour
{
    int[] max = new int[16];        //최대 교통량
    float[] speed_coef = new float[8];    //기울기
    float[] speed_const = new float[8];    //속도 상수
    float[] traffic_const = new float[4];   //교통량 상수
    float[,] traffic_coef = new float[4, 3]; //교통량 기울기
    public int CCTV_cnt = 16;
    public GameObject[] CCTV = new GameObject[16]; 
    // Start is called before the first frame update
    void Start()
    {
        DirectoryInfo di = new DirectoryInfo(@"LearningData");
        StreamReader speed_reader = new StreamReader(di.FullName + "/" + "model2_speed_data.csv");
        StreamReader traffic_reader = new StreamReader(di.FullName + "/" + "model2_traffic_data.csv");

        int cnt = 0;

        while (cnt < 8)  //speed 파일 읽기 시작
        {
            string data_String = speed_reader.ReadLine();

            var data_values = data_String.Split(','); //string, string타입
            UnityEngine.Debug.Log(data_values[0]);
            UnityEngine.Debug.Log(data_values[1]);
            UnityEngine.Debug.Log(data_values[2]);
            speed_coef[cnt] = (float)(double.Parse(data_values[0]));
            speed_const[cnt] = (float)(double.Parse(data_values[1]));
            max[cnt] = int.Parse(data_values[2]);
            cnt++;
        }

        cnt = 0;

        while (cnt < 4)  //traffic 파일 읽기 시작
        {
            string data_String = traffic_reader.ReadLine();

            var data_values = data_String.Split(','); //string, string타입
            traffic_const[cnt] = (float)(double.Parse(data_values[0]));
            traffic_coef[cnt, 0] = Mathf.Abs((float)(double.Parse(data_values[1])));
            traffic_coef[cnt, 1] = Mathf.Abs((float)(double.Parse(data_values[2])));
            traffic_coef[cnt, 2] = Mathf.Abs((float)(double.Parse(data_values[3])));
            cnt++;
        }

        max[8] = (int)(traffic_coef[1, 0] * max[0]); //x1_1 구간 최대 교통량
        max[9] = (int)(traffic_coef[2, 0] * max[1]); //x2_1 구간 최대 교통량
        max[10] = (int)(traffic_coef[3, 1] * max[2]); //x3_1 구간 최대 교통량
        max[11] = (int)(traffic_coef[0, 2] * max[3]); //x4_1 구간 최대 교통량
        max[12] = (int)(traffic_coef[1, 0] * max[0]); //x1_2 구간 최대 교통량
        max[13] = (int)(traffic_coef[0, 1] * max[1]); //x2_2 구간 최대 교통량
        max[14] = (int)(traffic_coef[1, 2] * max[2]); //x3_2 구간 최대 교통량
        max[15] = (int)(traffic_coef[2, 2] * max[3]); //x4_2   구간 최대 교통량

        speed_reader.Close();
        traffic_reader.Close();
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

        traffic[8] = (traffic[0] * traffic_coef[1, 0]);
        traffic[9] = (traffic[1] * traffic_coef[2, 0]);
        traffic[10] = (traffic[2] * traffic_coef[3, 1]);
        traffic[11] = (traffic[3] * traffic_coef[0, 2]);

        traffic[12] = (traffic[0] * traffic_coef[1, 0]);
        traffic[13] = (traffic[1] * traffic_coef[0, 1]);
        traffic[14] = (traffic[2] * traffic_coef[1, 2]);
        traffic[15] = (traffic[3] * traffic_coef[2, 2]);

        traffic[4] = (int)(traffic[(int)xName.x1] * traffic_coef[0, 0]) + 
            traffic[(int)x_1_Name.x4_1] - traffic[(int)x_2_Name.x2_2] + traffic_const[0];
        traffic[5] = (int)(traffic[(int)xName.x2] * traffic_coef[1, 1]) - 
            traffic[(int)x_1_Name.x1_1] + traffic[(int)x_2_Name.x3_2] + traffic_const[1];
        traffic[6] = (int)(traffic[(int)xName.x3] * traffic_coef[2, 1]) + 
            traffic[(int)x_1_Name.x2_1] + traffic[(int)x_2_Name.x4_2] + traffic_const[2];
        traffic[7] = (int)(traffic[(int)xName.x4] * traffic_coef[3, 2]) + 
            traffic[(int)x_1_Name.x3_1] + traffic[(int)x_2_Name.x1_2] + traffic_const[3];

        for (int i = 4; i < CCTV_cnt; i++)
        {
            CCTV[i].GetComponent<cshCCTVData>().congestion =
                Mathf.Abs((float)traffic[i] / max[i] * 100.0f);
        }   //혼잡도


        for(int i=0; i<8; i++)
        {
            if(i==2)
                CCTV[i].GetComponent<cshCCTVSliderData>().velocity =
                    Mathf.Ceil(-speed_coef[i] * (CCTV[i].GetComponent<cshCCTVSliderData>().congestion / 100.0f) + speed_const[i]);
            else
                CCTV[i].GetComponent<cshCCTVData>().velocity =
                    Mathf.Ceil(-speed_coef[i] * (CCTV[i].GetComponent<cshCCTVData>().congestion / 100.0f) + speed_const[i]);
        }
            //속도
    }
        
}
