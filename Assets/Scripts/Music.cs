using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    public AudioSource BGM;
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BGM.volume = musicVolume;
    }

    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}
