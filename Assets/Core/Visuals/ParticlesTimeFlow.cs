using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0618

public class ParticlesTimeFlow : MonoBehaviour {

    //Warning, playbackSpeed is obsolete
    //Gets all childrens' particles and changes simulation speed

    private ParticleSystem[] particles;

    private void Start()
    {
        particles = GetComponentsInChildren<ParticleSystem>();
    }

    void Update () {
        if (particles[0].playbackSpeed != GlobalSettings.singleton.TimeFlow)
        {
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].playbackSpeed = Mathf.Abs(GlobalSettings.singleton.TimeFlow);
            }
        }
	}
}
