using System.Collections.Generic;
using UnityEngine;

public class ARVoiceManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip sayaInginClip;
    public AudioClip sayaMelihatClip;

    public List<MarkerTrigger> activeMarkers = new List<MarkerTrigger>();

    public void MarkerFound(string markerName)
    {
        if (!activeMarkers.Exists(m => m.markerName == markerName))
        {
            activeMarkers.Add(new MarkerTrigger { markerName = markerName });
            CekDanMainkanSuara();
        }
    }

    public void MarkerLost(string markerName)
    {
        activeMarkers.RemoveAll(m => m.markerName == markerName);
    }

    void CekDanMainkanSuara()
    {
        bool ingin = activeMarkers.Exists(m => m.markerName == "I_Want");
        bool melihat = activeMarkers.Exists(m => m.markerName == "I_See");

        string objek = null;

        foreach (var marker in activeMarkers)
        {
            if (marker.markerName != "I_Want" && marker.markerName != "I_See")
            {
                objek = marker.markerName;
                break;
            }
        }

        if (objek == null) return;

        AudioClip clip = null;

        if (ingin)
            clip = Resources.Load<AudioClip>("Sound-PCES-mp3/Saya ingin " + objek);
        else if (melihat)
            clip = Resources.Load<AudioClip>("Sound-PCES-mp3/Saya melihat " + objek);
        else
            clip = Resources.Load<AudioClip>("Sound-PCES-mp3/" + objek);

        if (clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio tidak ditemukan untuk: " + objek);
        }
    }

    [System.Serializable]
    public class MarkerTrigger
    {
        public string markerName;
    }
}
