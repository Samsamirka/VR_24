using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRtest : MonoBehaviour
{
    static public int a;
    public int x = 0;
    public Text Mytxt;
    public int z;
    public int y;
    public int c;

    void Start()
    {
        Debug.Log("First programme!");
    }

    void FixedUpdate()
    {
        x++;
        Mytxt.text = x.ToString();
        Debug.Log(x);
        if (x >= 100) this.gameObject.SetActive(false);
    }


    public void ClickBut()
    {
        z = Random.Range(0, 255);
        y = Random.Range(0, 255);
        c = Random.Range(0, 255);
        this.GetComponent<Renderer>().material.color = new Color32((byte)z, (byte)y, (byte)c, 1);
    }
}


