namespace BackendAPI.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AnomalyDetector
    {
        private readonly Queue<float> _window;
        private readonly int _windowSize;
        private readonly float _zScoreThreshold;

        public AnomalyDetector(int windowSize = 30, float zScoreThreshold = 2.5f)
        {
            _windowSize = windowSize;
            _zScoreThreshold = zScoreThreshold;
            _window = new Queue<float>();
        }

        public bool Predict(float newValue)
        {
            if (_window.Count < _windowSize)
            {
                _window.Enqueue(newValue);
                return false; // Not enough data yet to determine anomaly
            }

            float mean = _window.Average();
            float stdDev = (float)Math.Sqrt(_window.Select(v => Math.Pow(v - mean, 2)).Average());

            float zScore = stdDev != 0 ? (newValue - mean) / stdDev : 0;

            _window.Dequeue();
            _window.Enqueue(newValue);

            return Math.Abs(zScore) > _zScoreThreshold;
        }
    }

}
