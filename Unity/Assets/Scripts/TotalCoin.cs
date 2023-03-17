using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalCoin : MonoBehaviour
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
        PointText.GetComponent<TMP_Text>().text = "Monedas: " + point;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Point")
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(monedaSound, transform.position);
            point++;
            Debug.Log(point); //Para que se muestren los puntos por consola dentro de Unity.
        }

    }
}
