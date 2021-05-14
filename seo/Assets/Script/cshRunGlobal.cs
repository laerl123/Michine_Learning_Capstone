using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshRunGlobal : MonoBehaviour
{
    public GameObject global;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(global);
        SceneManager.LoadScene("1stModel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}