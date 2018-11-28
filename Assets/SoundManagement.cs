using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagement : MonoBehaviour {

    public Scrollbar soundL;
    public Scrollbar musicL;
    public static float soundLevel;

    public AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        soundLevel = soundL.value;

        source.volume = musicL.value;
    }
}
