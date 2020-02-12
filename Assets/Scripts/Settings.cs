using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private Text persenTeks;

    // Start is called before the first frame update
    void Start()
    {
        persenTeks = GameObject.Find("TxtVolume").GetComponent<Text>();
    }

    // teks untuk persen
    public void setVolumeTxt(float value)
    {
        persenTeks.text = Mathf.RoundToInt(value * 100) + " %";
    }

}
