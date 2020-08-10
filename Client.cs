using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;

public class Client : MonoBehaviour
{
    TcpClient tcpClient;
    // Start is called before the first frame update

    private void Awake()
    {
        Application.OpenURL(Application.dataPath + "/Node/Start.bat");
    }

    void Start()
    {
        Invoke("NewClient",2f);
    }


    void NewClient()
    {
        tcpClient = new TcpClient();
        tcpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9878));

        // Translate the passed message into ASCII and store it as a Byte array.
        Byte[] data = System.Text.Encoding.ASCII.GetBytes("Client connecting...");

        // Get a client stream for reading and writing.
        //  Stream stream = client.GetStream();

        NetworkStream stream = tcpClient.GetStream();

        // Send the message to the connected TcpServer.
        stream.Write(data, 0, data.Length);

        Debug.Log("Sent: Client connecting...");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
