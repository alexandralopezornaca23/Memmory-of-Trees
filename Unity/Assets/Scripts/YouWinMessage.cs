using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class YouWinMessage : MonoBehaviour
{
    public AudioClip winSound;
    public GameObject activarTextoHasGanado;

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(winSound, transform.position);
        activarTextoHasGanado.SetActive(true);
        StartCoroutine(WaitForSec());
    }

    private IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
