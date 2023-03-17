using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    
    public AudioClip monedaSound;
    public int point = 0;
    GameObject PointText;


    // Start is called before the first frame update
    void Start()
    {
        PointText = GameObject.FindWithTag("textPoints");
    }

    // Update is called once per frame
    void Update()
    {
        PointText.GetComponent<Text>().text = "Monedas:" + point;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Point")
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(monedaSound, transform.position);
            point++;
        }

    }

}


