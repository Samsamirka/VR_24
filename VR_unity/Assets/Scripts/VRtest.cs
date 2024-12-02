using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRtest : MonoBehaviour
{
    static public int a;
    public int x = 0;
    public Text Mytxt;
    static public int z;
    static public int y;
    static public int c;

    static public GameObject first;

    void Start()
    {
        Debug.Log("First programme!");
    }

    void FixedUpdate()
    {
        x++;
        Mytxt.text = x.ToString();
        Debug.Log(x);
        // if (x >= 100) this.gameObject.SetActive(false);
        
    }

    public void OnCollisionEnter(Collision collision)
    {

    }

    public void OnTriggerStay(Collider other)
    {
        z = Random.Range(0, 255);
        y = Random.Range(0, 255);
        c = Random.Range(0, 255);
        this.GetComponent<Renderer>().material.color = new Color32((byte)z, (byte)y, (byte)c, 1);
    }
}


