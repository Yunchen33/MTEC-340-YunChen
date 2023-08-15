using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    private static BGMusic bgMusic;

    private void Awake()
    {
        if(bgMusic == null)
        {
            bgMusic = this;
            DontDestroyOnLoad(bgMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
