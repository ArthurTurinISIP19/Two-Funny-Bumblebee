using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasEffect : MonoBehaviour
{
    private CircleCollider2D _cc;
    private AudioSource audioSrc;
    [SerializeField] private AudioClip gas;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        _cc = GetComponent<CircleCollider2D>();

        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        audioSrc.PlayOneShot(gas);
        yield return new WaitForSeconds(1.8f);
        _cc.enabled = false;

        yield return new WaitForSeconds(2f);
        _cc.enabled = true;
        StartCoroutine(Restart());
    }
}
