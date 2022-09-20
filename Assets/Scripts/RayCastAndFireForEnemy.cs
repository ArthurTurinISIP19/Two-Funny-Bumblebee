using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayCastAndFireForEnemy : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _layerMask;

    [Header("Fire Directions")]
    [SerializeField] private bool _upFire = false;
    [SerializeField] private bool _downFire = false;
    [SerializeField] private bool _leftFire = false;
    [SerializeField] private bool _rightFire = false;

    public AudioClip gun;
    private AudioSource audioSrc;
    private Vector2 _direction;

    private bool _isReloaded = true;

    public event UnityAction attack;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        gun = Resources.Load<AudioClip>("Gun");

        if (_upFire) { _direction = Vector2.up; }
        if (_downFire) { _direction = Vector2.down; }
        if (_leftFire) { _direction = Vector2.left; }
        if (_rightFire) { _direction = Vector2.right; }
    }

    private void FixedUpdate()
    {
        RaycastHit2D checkPlayer = Physics2D.Raycast(transform.position, transform.TransformDirection(_direction), _rayDistance, _layerMask);
        if(checkPlayer.collider != null)
        {
            if (checkPlayer.collider.gameObject.layer == 7 && _isReloaded)
            {
                Fire(checkPlayer);
            }
        }
    }
    private void Fire(RaycastHit2D checkPlayer)
    {
        if(gameObject.tag == "Gun")
        {
            audioSrc.PlayOneShot(gun);
        }

        attack?.Invoke();   
        _isReloaded = false;
        StartCoroutine(Reload());
        TryGetComponent(out BulletSpawner bulletspawner);
        bulletspawner.Fire();
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        _isReloaded = true;
    }
}
