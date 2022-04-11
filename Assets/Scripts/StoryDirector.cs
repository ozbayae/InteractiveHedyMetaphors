using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StoryDirector : MonoBehaviour
{
    
    //list of playable directors 
    [SerializeField]
    public List<PlayableDirector> playableDirectors;
    //counter for current playable director
    private int _currentDirector = 0;

    private void Start()
    {
        //subcribe to interactablegeneric onclick event
        InteractableGeneric.OnClick += PlayNextDirector;
    }
    
    private void PlayNextDirector()
    {
        if (_currentDirector < playableDirectors.Count)
        {
            playableDirectors[_currentDirector].Play();
            _currentDirector++;
        }
    }
    
    private void OnDestroy()
    {
        //unsubcribe from interactablegeneric onclick event
        InteractableGeneric.OnClick -= PlayNextDirector;
    }
    
}
