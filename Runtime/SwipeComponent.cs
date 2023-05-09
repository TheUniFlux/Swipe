/*
Copyright (c) 2023 Xavier Arpa López Thomas Peter ('Kingdox')

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Kingdox.UniFlux.Swipe
{
    [Serializable] public class SwipeComponent
    {
        [SerializeField] private float minSwipeDistance = default;
        public float MinSwipeDistance
        {
            get => minSwipeDistance;
            set => minSwipeDistance = value;
        }
        public Action OnSwipeUp;
        public Action OnSwipeDown;
        public Action OnSwipeLeft;
        public Action OnSwipeRight;
        private Vector2 _startPos;
        private bool _isSwiping;
        
        public void Update_Swipe()
        {
            #if UNITY_EDITOR || !(UNITY_ANDROID || UNITY_IOS)
            if (Input.GetMouseButtonDown(0))
            {
                _isSwiping = true;
                _startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isSwiping = false;
            }

            if (_isSwiping)
            {
                Vector2 currentPos = Input.mousePosition;
                Vector2 delta = currentPos - _startPos;

                if (delta.magnitude >= minSwipeDistance)
                {
                    if (Mathf.Abs(delta.x) >= Mathf.Abs(delta.y))
                    {
                        // Swipe horizontal
                        if (delta.x < 0) OnSwipeLeft.Invoke();
                        else OnSwipeRight.Invoke();
                        _isSwiping = false;
                    }
                    else
                    {
                        // Swipe vertical
                        if (delta.y < 0) OnSwipeDown.Invoke();
                        else OnSwipeUp.Invoke();
                        _isSwiping = false;
                    }
                }
            }
            #else
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _isSwiping = true;
                        _startPos = touch.position;
                        break;
                    case TouchPhase.Moved:
                        if (_isSwiping)
                        {
                            Vector2 delta = touch.position - _startPos;
                            if (Mathf.Abs(delta.x) >= minSwipeDistance && Mathf.Abs(delta.y) < Mathf.Abs(delta.x))
                            {
                                // Swipe horizontal
                                if (delta.x < 0) OnSwipeLeft?.Invoke();
                                else OnSwipeRight?.Invoke();
                                _isSwiping = false;
                            }
                            else if (Mathf.Abs(delta.y) >= minSwipeDistance && Mathf.Abs(delta.x) < Mathf.Abs(delta.y))
                            {
                                // Swipe vertical
                                if (delta.y < 0) OnSwipeDown?.Invoke();
                                else OnSwipeUp?.Invoke();
                                _isSwiping = false;
                            }
                        }
                        break;
                    case TouchPhase.Ended:
                        _isSwiping = false;
                        break;
                }
            }
            #endif
        }
    }
}