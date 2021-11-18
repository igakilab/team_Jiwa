using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Text;

public class messageLogController : MonoBehaviour
{
    private Queue<string> messageQueue;
    private int maxLogMessageLength = 4;
    private System.Text.StringBuilder Sb;
    private bool islogUpdated;

    private int times = 0;
    public Text messageLog;

    // Start is called before the first frame update
    void Start()
    {
        messageQueue = new Queue<string>();
        Sb = new System.Text.StringBuilder();
        Sb.Clear();
        islogUpdated = false;
        updateLogMessage();
        times = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (islogUpdated)
        {
            updateLogMessage();
            islogUpdated = false;
        }
    }

    public void enqueueMessage(string message)
    {
        islogUpdated = true;
        messageQueue.Enqueue(message);

        while(messageQueue.Count > maxLogMessageLength)
        {
            messageQueue.Dequeue();
        }
    }

    private void updateLogMessage()
    {
        Sb.Clear();
        foreach(string msg in messageQueue)
        {
            Sb.Append(msg+"\n");
        }
        messageLog.text = Sb.ToString();
    }
}
