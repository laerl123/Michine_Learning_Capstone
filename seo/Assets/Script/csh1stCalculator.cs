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
    }

    // Update is called once per frame
    void Update()
    {

        //T1 = (-2.63 * T2) + (1.9 * T3) - T4
        //T2 = (T1 / 2.63) - (1.9 * T3 / 2.63) + (T4 / 2.63) 
        //T3 = (T1 / 1.9) + (2.63 * T2 / 1.9) + (T4 / 1.9)
        //T4 = T1 + (-2.63 * T2) + (1.9 * T3)

        /*
        수원신갈-기흥 7292
        기흥-기흥동탄 7123
        기흥동탄-동탄 6531
        */
    }
}
