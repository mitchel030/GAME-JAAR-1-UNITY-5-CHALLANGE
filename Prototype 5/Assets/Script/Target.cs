using System.Collections;                                         //Mitchel Wingelaar
using System.Collections.Generic;                                 // klas 1c1
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float forceMin = 10;
    [SerializeField] private float forceMax = 14;

    [SerializeField] private float torqueMax = 10;

    [SerializeField] private float initialY = -2;
    [SerializeField] private float initialPosXRange = 4;

    [SerializeField] private int score = 10;

    [SerializeField] private ParticleSystem explosionParticle;

    private GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        transform.position = new Vector3(Random.Range(-initialPosXRange, initialPosXRange), initialY, 0);

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.up * Random.Range(forceMin, forceMax), ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(-torqueMax, torqueMax), Random.Range(-torqueMax, torqueMax), Random.Range(-torqueMax, torqueMax)), ForceMode.Impulse);
    }

    void OnMouseDown()    
    {
        if (gameManager?.IsGameOver() == true) return; // if game over

        if (explosionParticle)
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }

        AudioClip clip = GetComponent<AudioSource>()?.clip;

        if (clip)
        {
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
        }

        Destroy(gameObject);

        gameManager?.AddScore(score);
    }

    void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);

        if (CompareTag("Good"))
        {
            gameManager?.GameOver();
        }
    }
}
