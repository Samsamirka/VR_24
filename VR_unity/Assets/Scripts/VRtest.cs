using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRtest : MonoBehaviour
{
    public GameObject Cube;
    public int x = 0;
    public Text Mytxt;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("First programme!");
    }

    // Update is called once per frame
    void Update()
    {
        x++;
        Mytxt.text = x.ToString();
        Debug.Log(x);
        if (x >= 100)
        {
            Cube.SetActive(false);
        }
    }
}
