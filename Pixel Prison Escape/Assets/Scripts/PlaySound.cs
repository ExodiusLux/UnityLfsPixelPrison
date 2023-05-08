/***************************************************************
*file: PlaySound.cs
*author: I. La Polla
*class: CS 4700 – Game Development
*assignment: final project
*date last modified: 5/7/2023
*
*purpose: This program allows code to be added to items to allow 
* them to make particular sounds on demand
*
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> audioClips = new List<AudioClip>();

    //function: Start
    // purpose: Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    //function: Update
    // purpose: Update is called once per frame
    void Update()
    {
        
    }

    //function: Play
    // purpose: Play is used to play whatever sound needs to be played
    public void Play(int noise)
	{
        source.clip = audioClips[noise];
        source.Play();
	}
}
