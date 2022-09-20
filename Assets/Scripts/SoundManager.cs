using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{

    public static AudioClip[] playerAttack = new AudioClip[3];
    public static AudioClip playerDamage, playerJump, playerBulletDestroy, enemyDie, enemyFalling, donk, bang, lightning, fireFighter, shipBell, saw, finish;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        for (int i = 0; i < playerAttack.Length; i++)
        {
            playerAttack[i] = Resources.Load<AudioClip>($"PlayerHit{i+1}");
        }

        donk = Resources.Load<AudioClip>("Ding");

        finish = Resources.Load<AudioClip>("Victory");

        playerDamage = Resources.Load<AudioClip>("Damage");
        playerJump = Resources.Load<AudioClip>("Jump");
        playerBulletDestroy = Resources.Load<AudioClip>("Water");

        enemyDie = Resources.Load<AudioClip>("Poof");
        enemyFalling = Resources.Load<AudioClip>("Falling");
        saw = Resources.Load<AudioClip>("Saw");
        bang = Resources.Load<AudioClip>("Bang");
        lightning = Resources.Load<AudioClip>("lightning");
        fireFighter = Resources.Load<AudioClip>("FireFighter");
        shipBell = Resources.Load<AudioClip>("ShipBell");
        
    }

    public static void PlayerAttack(int i)
    {
        audioSrc.PlayOneShot(playerAttack[i]);
    }
    public static void PlayerDamage()
    {
        audioSrc.PlayOneShot(playerDamage);
    }
    public static void PlayerJump()
    {
        audioSrc.PlayOneShot(playerJump);
    }
    public static void PlayerBulletDestroy()
    {
        audioSrc.PlayOneShot(playerBulletDestroy, 0.5f);
    }
    public static void EnemyDie()
    {
        audioSrc.PlayOneShot(enemyDie, 2f);
    }
    public static void EnemyFalling()
    {
        audioSrc.PlayOneShot(enemyFalling, 0.1f);
    }
    public static void Donk()
    {
        audioSrc.PlayOneShot(donk);
    }
    public static void Bang()
    {
        audioSrc.PlayOneShot(bang, 0.1f);
    }
    public static void Lightning()
    {
        audioSrc.PlayOneShot(lightning, 0.5f);
    }
    public static void FireFighter()
    {
        audioSrc.PlayOneShot(fireFighter, 1f);
    }
    public static void ShipBell()
    {
        audioSrc.PlayOneShot(shipBell, 1f);
    }
    public static void Finish()
    {
        audioSrc.PlayOneShot(finish, 1f);
    }
}
