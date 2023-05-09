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
namespace Kingdox.UniFlux.Swipe
{
    public static partial class SwipeService // Data
    {
        private static partial class Data
        {
        }
    }
    public static partial class SwipeService // Key
    {
        public static partial class Key
        {
            private const string K =  nameof(Swipe) + ".";
            public const string  OnSwipeUp = K + nameof(OnSwipeUp);
            public const string  OnSwipeDown = K + nameof(OnSwipeDown);
            public const string  OnSwipeLeft = K + nameof(OnSwipeLeft);
            public const string  OnSwipeRight = K + nameof(OnSwipeRight);
            public const string  MinSwipeDistance = K + nameof(MinSwipeDistance);
        }
    }
    public static partial class SwipeService // Methods
    {
        public static void OnSwipeUp() => Key.OnSwipeUp.Dispatch();
        public static void OnSwipeDown() => Key.OnSwipeDown.Dispatch();
        public static void OnSwipeLeft() => Key.OnSwipeLeft.Dispatch();
        public static void OnSwipeRight() => Key.OnSwipeRight.Dispatch();
        public static float MinSwipeDistance
        {
            get => Key.MinSwipeDistance.Dispatch<float>();
            set => Key.MinSwipeDistance.Dispatch(value);
        }
    }
}