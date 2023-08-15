using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField] AudioSource clickPlayer;

    public void playThisSFX()
    {
        clickPlayer.Play();
    }

}
