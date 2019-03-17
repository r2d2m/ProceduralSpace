using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMath.Noise
{
    public interface INoiseFilter
    {
        float Evaluate(Vector3 point);
    }
}
