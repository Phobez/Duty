using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour, IInteractable<GameObject> {

    public GameObject destination;

    private Vector3 targetCoords;
    private AudioSource audioSource;

    public AudioClip sound;

    public bool automatic = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        targetCoords = destination.transform.position;
    }

    public void Interact(GameObject player)
    {
        player.transform.position = targetCoords;
    }

    public Vector3 GetTargetCoords()
    {
        return targetCoords;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (automatic && collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(sound);
            collision.gameObject.transform.position = targetCoords;
        }
    }
}
