using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using UnityEngine;

public class csh1stCalculator : MonoBehaviour
{
    public int CCTV_cnt = 4;
    public GameObject[] CCTV = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        Process ps = new Process();
        ps.StartInfo.FileName = "C:/Users/seo/AppData/Local/Programs/Python/Python38/python.exe";
        ps.StartInfo.Arguments = "C:/Users/seo/Desktop/Michine_Learning_Capstone/seo/Assets/PythonCode/test.py";
        ps.StartInfo.CreateNoWindow = true;
        ps.StartInfo.UseShellExecute = true;
        ps.Start();
    }

    // Update is called once per frame
    void Update()
    {
        int[] sum = new int[4];
        for(int i = 0; i<CCTV_cnt; i++)
        {
            for (int j = 0; j<CCTV_cnt; j++)
                sum[i] += CCTV[j].GetComponent<cshCCTVData>().congestion;
            
            CCTV[i].GetComponent<cshCCTVData>().velocity = sum[i] / CCTV_cnt;
        }
    }
}
