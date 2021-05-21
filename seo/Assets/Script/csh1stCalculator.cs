using System.Collections;
using System.Collections.Generic;
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
        int[] sum = new int[4];
        for(int i = 0; i<CCTV_cnt; i++)
        {
            for (int j = 0; j<CCTV_cnt; j++)
                sum[i] += CCTV[j].GetComponent<cshCCTVData>().congestion;
            
            CCTV[i].GetComponent<cshCCTVData>().velocity = sum[i] / CCTV_cnt;
        }
    }
}
