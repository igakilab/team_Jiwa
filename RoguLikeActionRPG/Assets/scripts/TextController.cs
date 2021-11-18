using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txt;

    public float speed = 1.0f;
    private float time;

    // Update is called once per frame
    void Update()
    {
        txt.color = GetAlphaColor(txt.color);
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = 0.5f * Mathf.Sin(time) + 0.5f;

        return color;
    }
}
