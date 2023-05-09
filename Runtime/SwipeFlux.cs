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
using UnityEngine;
namespace Kingdox.UniFlux.Swipe
{
    public sealed class SwipeFlux : MonoFlux
    {
        [SerializeField] private SwipeComponent swipe = new()
        {
            OnSwipeUp = SwipeService.OnSwipeUp,
            OnSwipeDown = SwipeService.OnSwipeDown,
            OnSwipeLeft = SwipeService.OnSwipeLeft,
            OnSwipeRight = SwipeService.OnSwipeRight
        };
        public float MinSwipeDistance
        {
            [Flux(SwipeService.Key.MinSwipeDistance)] get => swipe.MinSwipeDistance;
            [Flux(SwipeService.Key.MinSwipeDistance)] set => swipe.MinSwipeDistance = value;
        }
        private void Update() => swipe.Update_Swipe();
        [Flux(SwipeService.Key.OnSwipeUp)] private void OnSwipeUp() => print("OnSwipeUp");
        [Flux(SwipeService.Key.OnSwipeDown)] private void OnSwipeDown() => print("OnSwipeDown");
        [Flux(SwipeService.Key.OnSwipeLeft)] private void OnSwipeLeft() => print("OnSwipeLeft");
        [Flux(SwipeService.Key.OnSwipeRight)] private void OnSwipeRight() => print("OnSwipeRight");
    }
}