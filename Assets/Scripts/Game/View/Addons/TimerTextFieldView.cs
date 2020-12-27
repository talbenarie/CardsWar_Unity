using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.View.Addons
{
    public class OnTimerFinishedEvent : UnityEvent{}
    
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TimerTextFieldView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textField;
        private DateTime _currentTime;
        private DateTime _targetTime;
        private bool _active;

        public OnTimerFinishedEvent OnTimerFinished = new OnTimerFinishedEvent();

        public void Initialize(DateTime target)
        {
            _targetTime = target;
            _active = true;
        }

        private void OnTimerTick()
        {
            if (!_active) return;
            
            _currentTime = DateTime.Now;

            if (_currentTime > _targetTime)
            {
                _active = false;
                OnTimerFinished.Invoke();
            }

            TimeSpan ts = _targetTime - _currentTime;
            _textField.text = FormatTime(ts);
        }
        
        private void Update()
        {
            OnTimerTick();
        }

        private void OnValidate()
        {
            _textField = GetComponent<TextMeshProUGUI>();
        }

        private static string FormatTime(TimeSpan ts)
        {
            if (ts.TotalDays >= 3)
            {
                return ts.TotalDays + " Days";
            }
            else if (ts.TotalDays >= 1)
            {
                return ts.TotalDays + " D " + ts.Hours + " H";
            }
            else if (ts.TotalHours >= 1)
            {
                return ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
            }
            else
            {
                return ts.Minutes + ":" + ts.Seconds;
            }
        }
    }
}
