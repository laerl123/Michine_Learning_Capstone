using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshAllPanelControl : MonoBehaviour
{
    public GameObject[] CCTVs, panels;
    public bool state;
    // Start is called before the first frame update
    void Start()
    {
        state = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AllActivating()
    {
        if (state)
            for (int i = 0; i < panels.Length; i++)
            {
                Debug.Log("실행");
                panels[i].GetComponent<cshPanelActive>().Activating();
            }
        else if (!state)
            for (int i = 0; i < panels.Length; i++)
                panels[i].GetComponent<cshPanelActive>().Activating();
        else
            Debug.Log("에러");

        state = !state;
    }
}
