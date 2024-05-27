using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    [SerializeField] private int requiredGoldAmount = 100;

    private SoundsManager soundsManager;

    private void Awake()
    {
        soundsManager = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsManager>();

    }
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && EconomyManager.Instance.CurrentGold >= requiredGoldAmount)
        {
            yield return new WaitForSeconds(1f);
            soundsManager.PlaySFX(soundsManager.Portal);

            SceneManager.LoadScene(sceneToLoad);
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
        }
    }
}
