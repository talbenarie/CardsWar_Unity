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
        private bool _initialized;

        public OnTimerFinishedEvent OnTimerFinished = new OnTimerFinishedEvent();

        public void Initialize(DateTime target)
        {
            _targetTime = target;
            _active = true;
            _initialized = true;
        }

        public void Pause()
        {
            if (!_initialized)
            {
                return;
            }
            
            _active = false;
        }

        public void Resume()
        {
            if (!_initialized)
            {
                return;
            }
            
            _active = true;
        }
        
        private void OnTimerTick()
        {
            if (!_active) return;
            
            _currentTime = DateTime.Now;

            if (_currentTime > _targetTime)
            {
                _active = false;
                _initialized = false;
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
            String hours, minutes, seconds;

            hours = FormatToZeroBase(ts.Hours);
            minutes = FormatToZeroBase(ts.Minutes);
            seconds = FormatToZeroBase(ts.Seconds);
            
            if (ts.TotalDays >= 3)
            {
                return ts.TotalDays + " Days";
            }
            else if (ts.TotalDays >= 1)
            {
                return ts.TotalDays + " D " + hours + " H";
            }
            else if (ts.TotalHours >= 1)
            {
                return hours + ":" + minutes + ":" + seconds;
            }
            else
            {
                return minutes + ":" + seconds;
            }
        }

        private static string FormatToZeroBase(int num)
        {
            if (num < 10)
            {
                return "0" + num;
            }
            else
            {
                return num.ToString();
            }
        }
    }
}
