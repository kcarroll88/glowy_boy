using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    [SerializeField] AudioClip rubyPickupSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(rubyPickupSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
