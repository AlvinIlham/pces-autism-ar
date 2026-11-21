using System.Collections.Generic;
using UnityEngine;

public class MarkerAudioController : MonoBehaviour
{
    public AudioSource audioSource;

    // Status marker
    private HashSet<string> activeMarkers = new HashSet<string>();

    // Dictionary audio
    public List<AudioClip> individualClips; // Buku, Gelas, dll
    public List<AudioClip> sayaInginClips;  // Saya ingin Buku, Saya ingin Gelas, dll
    public List<AudioClip> sayaMelihatClips;// Saya melihat Buku, dll

    private Dictionary<string, AudioClip> individualDict = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> inginDict = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> melihatDict = new Dictionary<string, AudioClip>();

    void Start()
    {
        foreach (var clip in individualClips)
            individualDict[clip.name] = clip;

        foreach (var clip in sayaInginClips)
            inginDict[clip.name.Replace("Saya mau ", "")] = clip;

        foreach (var clip in sayaMelihatClips)
            melihatDict[clip.name.Replace("Saya melihat ", "")] = clip;
    }

    public void MarkerFound(string markerName)
    {
        activeMarkers.Add(markerName);
        PlayCombinedAudio();
    }

    public void MarkerLost(string markerName)
    {
        activeMarkers.Remove(markerName);
    }

    private void PlayCombinedAudio()
    {
        string[] objectMarkers = { "Buku", "Gelas", "Handuk", "HP", "Jagung", "Kerupuk", "Lego", "Penghapus", "Pensil", "Piring", "Bola", "Puzzle", "Rakik", "Salak", "Playdoh" };

        string result = "";

        foreach (string obj in objectMarkers)
        {
            if (activeMarkers.Contains("I_Want") && activeMarkers.Contains(obj) && inginDict.ContainsKey(obj))
            {
                result = "Saya ingin " + obj;
                audioSource.clip = inginDict[obj];
                audioSource.Play();
                return;
            }

            if (activeMarkers.Contains("I_See") && activeMarkers.Contains(obj) && melihatDict.ContainsKey(obj))
            {
                result = "Saya melihat " + obj;
                audioSource.clip = melihatDict[obj];
                audioSource.Play();
                return;
            }

            if (activeMarkers.Contains(obj) && individualDict.ContainsKey(obj))
            {
                result = obj;
                audioSource.clip = individualDict[obj];
                audioSource.Play();
                return;
            }
        }
    }
}
