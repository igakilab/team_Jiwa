using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    void Start()
    {
        this.Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = this.Player.transform.position;
        transform.position = new Vector3(PlayerPos.x, transform.position.y, transform.position.z);
        
    }
}
