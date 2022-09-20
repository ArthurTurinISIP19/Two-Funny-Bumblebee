using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Ant : MonoBehaviour
{
    [SerializeField] private int _hp = 200;
    [SerializeField] private Animator _animator;
    [SerializeField] private Fist _fistOne;
    [SerializeField] private Fist _fistTwo;
    [SerializeField] private Fist _secondHeadAction;
    [SerializeField] private Target _target;
    [SerializeField] private BossCar _carBoss;

    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Material _damageMaterial;
    [SerializeField] private Material _defaultMaterial;

    [SerializeField] private GameObject _hand1;
    [SerializeField] private GameObject _hand2;
    [SerializeField] private GameObject _secondHead;
    [SerializeField] private ParticleSystem _dieEff;

    [SerializeField] private GameObject _HUD;
    [SerializeField] private GameObject _finish;

    public event UnityAction<int> OnChangeStageOne;

    [SerializeField] private Component[] AntParts;

    private void OnEnable()
    {
        _fistOne.OnHpChange += ChangeHp;
        _fistTwo.OnHpChange += ChangeHp;
        _secondHeadAction.OnHpChange += ChangeHp;
    }
    private void OnDisable()
    {
        _fistOne.OnHpChange -= ChangeHp;
        _fistTwo.OnHpChange -= ChangeHp;
        _secondHeadAction.OnHpChange -= ChangeHp;
    }

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _defaultMaterial = _sr.material;

        AntParts = GetComponentsInChildren<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        StartCoroutine(StartTarget());
    }

    private void ChangeHp()
    {
        _hp--;
        StartCoroutine(VisualDamage());
        foreach (SpriteRenderer child in AntParts)
        {
            StartCoroutine(VD(child));
        }
        if (_hp == 150)
        {
            _carBoss.gameObject.SetActive(true);
            OnChangeStageOne?.Invoke(1);
        }
        if(_hp == 100)
        {
            _target.gameObject.SetActive(false);
            OnChangeStageOne?.Invoke(2);
        }
        if (_hp == 50)
        {
            _target.gameObject.SetActive(true);
            _target._speed = 0.1f;
            _animator.Play("StageLast");
            _carBoss.gameObject.SetActive(false);
            DieFists();
            _hand1.gameObject.SetActive(false);
            _hand2.gameObject.SetActive(false);
            _secondHead.gameObject.SetActive(true);
            OnChangeStageOne?.Invoke(3);
        }
        if(_hp <= 0)
        {
            Instantiate(_dieEff, _secondHead.transform.position, Quaternion.identity);
            _secondHead.gameObject.SetActive(false);
            gameObject.SetActive(false);
            _HUD.SetActive(false);
            //_finish.SetActive(true);
            //Time.timeScale = 0;
            SceneManager.LoadScene("Comix2");
        }
    }

    private void DieFists()
    {
        Instantiate(_dieEff, _hand1.transform.position, Quaternion.identity);
        Instantiate(_dieEff, _hand2.transform.position, Quaternion.identity);

    }
    IEnumerator VisualDamage()
    {
        for (int i = 0; i < 1; i++)
        {
            _sr.material = _damageMaterial;
            yield return new WaitForSeconds(0.1f);
            _sr.material = _defaultMaterial;
            yield return new WaitForSeconds(0.1f);
        }
       
    }

    IEnumerator VD(SpriteRenderer child)
    {
        for (int i = 0; i < 1; i++)
        {
            child.material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            yield return new WaitForSeconds(0.1f);
            child.material.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator StartTarget()
    {
        yield return new WaitForSeconds(4f);
        _target.gameObject.SetActive(true);
    }
}
