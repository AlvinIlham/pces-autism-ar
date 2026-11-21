using UnityEngine;
using Vuforia;

public class MarkerTrigger : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;
    public string markerName;
    public MarkerAudioController audioManager;

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            audioManager.MarkerFound(markerName);
        }
        else
        {
            audioManager.MarkerLost(markerName);
        }
    }

    void OnDestroy()
    {
        // Pastikan kita unsubscribe untuk mencegah memory leak
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
