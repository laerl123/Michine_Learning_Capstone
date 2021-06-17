using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class cshFirstScreen : MonoBehaviour
{
    public CanvasGroup alert;
    public GameObject model_select;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("runFirst", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void runFirst()
    {
        alert.gameObject.SetActive(true);
        alert.GetComponent<cshAlertFade>().startFadeIn();

        DirectoryInfo di = new DirectoryInfo(@"LearningData");
        if (di.Exists == false)
        {
            di.Create();
        }

        string file_name = "model1_speed_data.csv";
        FileStream fs =
            new FileStream(di.FullName + "/" + file_name, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);

        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        var ep = new IPEndPoint(IPAddress.Parse("3.36.119.251"), 8080);
        sock.Connect(ep);
        Debug.Log("연결 성공");


        byte[] receiverBuff = new byte[8192];
        byte[] buff = Encoding.UTF8.GetBytes(file_name);

        sock.Send(buff, SocketFlags.None);
        Debug.Log("보낸 데이터 : " + file_name);

        int check = sock.Receive(receiverBuff);
        bw.Write(receiverBuff);
        bw.Close();
        fs.Close();


        file_name = "model1_traffic_data.csv";
        fs =
            new FileStream(di.FullName + "/" + file_name, FileMode.Create, FileAccess.Write);
        bw = new BinaryWriter(fs);

        buff = Encoding.UTF8.GetBytes(file_name);

        sock.Send(buff, SocketFlags.None);
        Debug.Log("보낸 데이터 : " + file_name);

        receiverBuff = new byte[8192];
        check = sock.Receive(receiverBuff);
        bw.Write(receiverBuff);
        bw.Close();
        fs.Close();


        file_name = "model2_speed_data.csv";
        fs =
            new FileStream(di.FullName + "/" + file_name, FileMode.Create, FileAccess.Write);
        bw = new BinaryWriter(fs);

        buff = Encoding.UTF8.GetBytes(file_name);

        receiverBuff = new byte[8192];
        sock.Send(buff, SocketFlags.None);
        Debug.Log("보낸 데이터 : " + file_name);

        check = sock.Receive(receiverBuff);
        bw.Write(receiverBuff);
        bw.Close();
        fs.Close();


        file_name = "model2_traffic_data.csv";
        fs =
            new FileStream(di.FullName + "/" + file_name, FileMode.Create, FileAccess.Write);
        bw = new BinaryWriter(fs);

        buff = Encoding.UTF8.GetBytes(file_name);

        receiverBuff = new byte[8192];
        sock.Send(buff, SocketFlags.None);
        Debug.Log("보낸 데이터 : " + file_name);

        check = sock.Receive(receiverBuff);
        bw.Write(receiverBuff);

        bw.Close();
        fs.Close();

        buff = Encoding.UTF8.GetBytes("EndDownload");
        sock.Send(buff, SocketFlags.None);

        Invoke("onModelSelect", 2.5f);

    }

    void onModelSelect()
    {
        model_select.SetActive(true);
    }
}
