using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _originalY;
     static AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        Time.timeScale = 1;
        _originalY = transform.position.y;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_target.transform.position.x, _originalY, transform.position.z), 1f);
    }
    public static void StopSound()
    {
        audioSrc.Pause();
    }
    public IEnumerator Shake (float duration, float magnutude)
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0.0f;

        while( elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnutude;
            float y = Random.Range(-1f, 1f) * magnutude;

            transform.position = new Vector3(transform.position.x + x ,  transform.position.y + y, originalPos.z);

            elapsed += 0.03f;
            yield return null;
        }
    }
}
