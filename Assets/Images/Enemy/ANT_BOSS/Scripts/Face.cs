using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteDefault;
    [SerializeField] private Sprite _newSprite;
    [SerializeField] private Ant _ant;

    private void OnEnable()
    {
        _ant.OnChangeStageOne += ChangeSprite;
    }
    private void OnDisable()
    {
        _ant.OnChangeStageOne -= ChangeSprite;
    }
    private void ChangeSprite(int num)
    {
        if(num == 1)
        {
        _spriteDefault.sprite = _newSprite;
        }
    }


}
