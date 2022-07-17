using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] AudioClip dieGrab;
    [SerializeField] AudioClip dieShuffle;
    [SerializeField] AudioClip dieThrow;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //Dice.DiceRolling += PlayDieShuffle;
        print(_audioSource);
    }

    public void PlayDieGrab()
    {
        _audioSource.PlayOneShot(dieGrab);
    } 
    public void PlayDieShuffle()
    {
        _audioSource.PlayOneShot(dieShuffle);
    }
    
     public void PlayDieThrow()
    {
        _audioSource.PlayOneShot(dieThrow);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
