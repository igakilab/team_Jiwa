using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("“G‚ð”j‰ó!");
            Destroy(collision.gameObject);
        }
        
    }
}
