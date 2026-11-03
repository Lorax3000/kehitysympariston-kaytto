using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portalVisual;

    private AudioSource audioSource;
    private bool isOpen = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (portalVisual != null)
        {
            portalVisual.SetActive(false);
        }
    }

    public void OpenPortal()
    {
        if (isOpen)
            return;

        isOpen = true;

        if (portalVisual != null)
        {
            portalVisual.SetActive(true);
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }

        Debug.Log("The portal is open!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            GameManager.Instance.WinGame();
        }
    }
}