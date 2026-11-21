using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void KeluarAplikasi()
    {
        // Jika dijalankan di editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Jika dijalankan di perangkat (Android, iOS, dll)
        Application.Quit();
#endif
    }
}
