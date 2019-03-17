using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.ConditionalHide;

namespace SpaceMath.Noise {

    [System.Serializable]
    public class NoiseSettings
    {

        public enum FilterType { Simple, Ridgid };
        public FilterType filterType;

        [ConditionalHide("filterType", 0)]
        public SimpleNoiseSettings simpleNoiseSettings;
        [ConditionalHide("filterType", 1)]
        public RidgidNoiseSettings ridgidNoiseSettings;

        [System.Serializable]
        public class SimpleNoiseSettings
        {
            public float strength = 1f;
            [Range(1, 8)]
            public int numLayers = 1;
            public float baseRoughness = 1f;
            public float roughness = 2f;
            public float persistence = 0.5f;
            public Vector3 centre;
            public float minValue;
        }

        [System.Serializable]
        public class RidgidNoiseSettings : SimpleNoiseSettings
        {
            public float weightMultiplier = 0.8f;
        }
    }
}
