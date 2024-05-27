using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WorldTime
{
    public class WorldTime : Singleton<WorldTime>
    {
        public event EventHandler<TimeSpan> WorldTimeChanged;
        [SerializeField] public float TimeChanges = 25f;
        [SerializeField]
        public float _dayLength;
        public TimeSpan _currentTime;

        public float _minuteLength => _dayLength / WorldTimeConstants.MinutesInDay;
        private void Start()
        {
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()
        {
            _currentTime += TimeSpan.FromMinutes(1);
            WorldTimeChanged?.Invoke(this, _currentTime);
            yield return new WaitForSeconds(_minuteLength);
            StartCoroutine(AddMinute());
        }
    }
}