using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource fxSource;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }

        else 
        {
            instance = this; 
            DontDestroyOnLoad(this); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bell()
    {
        fxSource.Play();
    }
}
