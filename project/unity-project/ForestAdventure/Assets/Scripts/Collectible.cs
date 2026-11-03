using UnityEngine;

public class Collectible : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddCrystal();

            if (audioSource != null)
            {
                AudioSource.PlayClipAtPoint(
                    audioSource.clip,
                    transform.position
                );
            }

            Destroy(gameObject);
            Debug.Log("Crystal collected!");
        }
    }
}