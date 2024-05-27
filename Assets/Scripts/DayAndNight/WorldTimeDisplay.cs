using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace WorldTime
{
    public class WorldTimeDisplay : Singleton<WorldTimeDisplay>
    {
        [SerializeField]
        private WorldTime _worldTime;
        private TMP_Text _text;
        protected override void Awake()
        {
            base.Awake();
            _text = GetComponent<TMP_Text>();
            if (_worldTime != null)
            {
                _worldTime.WorldTimeChanged += OnWorldTimeChanged;
            }
            else
            {
                Debug.LogWarning("WorldTime is not assigned in WorldTimeDisplay script.");
            }
        }



        private void OnDestroy()
        {
            if (_worldTime != null)
            {
                _worldTime.WorldTimeChanged -= OnWorldTimeChanged;
            }
        }
        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            _text.SetText(newTime.ToString(@"hh\:mm"));
        }
    }
}


