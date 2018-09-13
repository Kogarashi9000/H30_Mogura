using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour {

    private static AudioSource Up;
    private static AudioSource Upforce;
    private static AudioSource Down;

	// Use this for initialization
	void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        Up = audioSources[2];
        Upforce = audioSources[1];
        Down = audioSources[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void PlaySeUp()
    {
        Up.PlayOneShot(Up.clip);
    }

    public static void PlaySeUpForce()
    {
        Upforce.PlayOneShot(Upforce.clip);
    }

    public static void PlaySeDown()
    {
        Down.PlayOneShot(Down.clip);
    }
}