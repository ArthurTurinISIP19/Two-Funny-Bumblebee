using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perforator : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float magnitudeX;
    [SerializeField] private float magnitudeY;

    [SerializeField] private trap _trap;
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _speedActivator = 0;

    private  AudioSource audioSrc;
    public  AudioClip perforator;

    private int _currentTarget = 1;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        perforator = Resources.Load<AudioClip>("Perforator");
    }

    private void OnEnable()
    {
        _trap.TrapPassed += SpeedOn;
    }
    private void OnDisable()
    {
        _trap.TrapPassed -= SpeedOn;
    }
    private void SpeedOn()
    {
        _speedActivator = 1;
    }

    public IEnumerator Shake(float duration, float magnutudeX, float magnutudeY)
    {
        transform.GetChild(0).gameObject.SetActive(true);

        Vector3 originalPos = transform.position;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnutudeX;
            float y = Random.Range(-1f, 1f) * magnutudeY;

            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        audioSrc.Stop();
        transform.GetChild(0).gameObject.SetActive(false);

    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _positions[_currentTarget], _speed * _speedActivator);
        if (transform.position == _positions[1] && _currentTarget == 1)
        {
            
            _speedActivator = 0;
            _currentTarget = 2;
            StartCoroutine(Waiter(1));
        }
        if (transform.position == _positions[2] && _currentTarget == 2)
        {
            audioSrc.PlayOneShot(perforator);
            
            _speedActivator = 0;
            _currentTarget = 0;
            StartCoroutine(Waiter(2));
            StartCoroutine(Shake(duration, magnitudeX, magnitudeY));
        }
        if (transform.position == _positions[0] && _currentTarget == 0)
        {
            _speedActivator = 0;
            _currentTarget = 1;
            StartCoroutine(Waiter(1));
        }
    }
    public IEnumerator Waiter(float duration)
    {
        
        yield return new WaitForSeconds(duration);
        _speedActivator = 1;
    }
}
