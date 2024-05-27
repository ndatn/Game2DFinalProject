using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerHolder : MonoBehaviour
{
    private static SoundsManager soundsManagerInstance;

    void Awake()
    {
        if (soundsManagerInstance == null)
        {
            GameObject soundsManagerObject = new GameObject("SoundsManager");
            soundsManagerInstance = soundsManagerObject.AddComponent<SoundsManager>();
            DontDestroyOnLoad(soundsManagerObject); // Đảm bảo không bị hủy khi chuyển scene
        }
    }
}
