using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public float _jumpForce = 5.5f;
    [SerializeField] private Transform _bulletSpawnPointLeft;
    [SerializeField] private Transform _bulletSpawnPointRight;
    [SerializeField] private GameObject _bullet;
    [SerializeField] public int _hp = 2;
    [SerializeField] public static bool _isDirectionRight = true;
    [SerializeField] private bool _isAllowToDamage = true;
    [SerializeField] private bool _isJumpReloaded = true;
    [SerializeField] private bool _isGround = false;
    [SerializeField] private PauseMenu _uiController;


    [SerializeField] private CameraMover _mainCamera;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Material _damageMaterial;
    [SerializeField] private Material _defaultMaterial;

    private bool isLeftDown;
    private bool isRightDown;
    private bool isFireDown;

    private Rigidbody2D _body;
    private Animator _animator;

    public event UnityAction OnHpChange;

    public AdPage adPage;
    private int _tryCount;

    private void Start()
    {
        Application.targetFrameRate = 60;

        _sr = GetComponent<SpriteRenderer>();
        _defaultMaterial = _sr.material;
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        adPage = GameObject.Find("AD").GetComponent<AdPage>();
        _tryCount = PlayerPrefs.GetInt("tryCount");
    }

    private void FixedUpdate()
    {
        if (isLeftDown == false && isRightDown == false && _isGround == true && _isDirectionRight == true)
        {
            _animator.SetInteger("State", 0);
        }
        if (isLeftDown == false && isRightDown == false && _isGround == true && _isDirectionRight == false)
        {
            _animator.SetInteger("State", 10);
        }
        if (isRightDown)
        {
            _body.transform.Translate(Vector2.right * _speed * Time.deltaTime);

            _animator.SetInteger("State", 1);

        }
        if (isLeftDown)
        {
            _body.transform.Translate(Vector2.left * _speed * Time.deltaTime);

            _animator.SetInteger("State", -1);

        }
        if (!_isGround && !isRightDown && !isLeftDown && !isFireDown)
        {
            _animator.SetInteger("State", 5);
        }
    }
    public void onLeftDown()
    {
        isLeftDown = true;
        _isDirectionRight = false;
        _animator.SetInteger("State", -1);

        StopCoroutine(WaitForFire());
    }
    public void onLeftUp()
    {
        isLeftDown = false;
        StopCoroutine(WaitForFire());
    }
    public void onRightDown()
    {
        isRightDown = true;
        _isDirectionRight = true;
        _animator.SetInteger("State", 1);

        StopCoroutine(WaitForFire());
    }
    public void onRightUp()
    {
        isRightDown = false;
        StopCoroutine(WaitForFire());
    }

    public void Fire()
    {
        SoundManager.PlayerAttack(Random.Range(0,3));

        isFireDown = true;
        if (_isDirectionRight!)
        {
            _animator.Play("FireR");
        }
        else
        {
            _animator.Play("FireL");
        }
        StartCoroutine(WaitForFire());
    }

    public void JumpBtn()
    {
        if (_isGround == true && _isJumpReloaded == true)
        {
            _isJumpReloaded = false;
            _isGround = false;

            StartCoroutine(ReloadJump());
            Jump();
        }
    }

    private void ApplyDamage()
    {
        SoundManager.PlayerDamage();
        OnHpChange?.Invoke();
        _isAllowToDamage = false;
        _hp -= 1;
        StartCoroutine(VisualDamage(_isGround));
        if (_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _tryCount++;
        PlayerPrefs.SetInt("tryCount", _tryCount);
        if (_tryCount % 4 == 0)
        {
            adPage.ShowAd();
        }
        _uiController.DiePause();
    }

    private void Jump()
    {
        SoundManager.PlayerJump();
        _isGround = false;

        StopCoroutine(WaitForJump());
        StartCoroutine(WaitForJump());

        if (isRightDown && !_isGround)
        {
            _animator.SetInteger("State", 3);
        }
        if (isLeftDown && !_isGround)
        {
            _animator.SetInteger("State", 4);
        }
        if (isLeftDown == false && isRightDown == false)
        {
            _animator.SetInteger("State", 5);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _isGround = true;
        }
        if ((collision.gameObject.layer == 3 || collision.gameObject.layer == 10 || collision.gameObject.layer == 13)  && _isAllowToDamage)
        {
            ApplyDamage();
        }
        if(collision.gameObject.layer == 14)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && _isAllowToDamage)
        {
            ApplyDamage();
        }
    }

    IEnumerator ReloadJump()
    {
        yield return new WaitForSeconds(0.2f);
        _isJumpReloaded = true;
    }
    IEnumerator WaitForJump()
    {
        _isGround = false;

        yield return new WaitForSeconds(0.1f);
        _body.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    IEnumerator WaitForFire()
    {
        yield return new WaitForSeconds(0.2f);
        TryGetComponent(out BulletSpawner bulletspawner);
        bulletspawner.Fire();
    }

    IEnumerator VisualDamage(bool _isGroundC)
    {
        StartCoroutine(_mainCamera.Shake(0.5f, 0.5f));

        if (_isGroundC == true)
        {
            _body.velocity = Vector2.up * 150f;
        }
        else if (_isGroundC == false)
        {
            _body.velocity = Vector2.up * 50f;
        }
        for (int i = 0; i < 6; i++)
        {
            _sr.material = _damageMaterial;
            yield return new WaitForSeconds(0.1f);
            _sr.material = _defaultMaterial;
            yield return new WaitForSeconds(0.1f);
        }
        _isAllowToDamage = true;
        StopCoroutine(VisualDamage(_isGroundC));
    }
}
