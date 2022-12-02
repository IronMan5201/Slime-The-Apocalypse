using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnedScript : MonoBehaviour
{
    public AudioSource burnedAudio;
    public Deathpit died;
    private static GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        burnedAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(died != null && died.objectDied == true)
        {
            burnedAudio.Play();
        }
    }
}
