using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouths : MonoBehaviour
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
        if (num == 2)
        {
            _spriteDefault.sprite = _newSprite;
        }
    }
}
