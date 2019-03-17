using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceMath.Noise;

public class ShapeGenerator {

    ShapeSettings shapeSettings;
    INoiseFilter[] noiseFilters;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.shapeSettings = settings;
        noiseFilters = new INoiseFilter[settings.noiseLayers.Length];

        for (int i = 0; i < noiseFilters.Length; i++)
        {
            noiseFilters[i] = NoiseFilterFactory.CreateNoiseFilter(settings.noiseLayers[i].noiseSettings);
        }
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float firstLayerValue = 0;
        float elevation = 0;

        if(noiseFilters.Length > 0)
        {
            firstLayerValue = noiseFilters[0].Evaluate(pointOnUnitSphere);
            if (shapeSettings.noiseLayers[0].enabled)
            {
                elevation = firstLayerValue;
            }
        }

        for (int i = 1; i < noiseFilters.Length; i++)
        {
            if (shapeSettings.noiseLayers[i].enabled)
            {
                float mask = (shapeSettings.noiseLayers[i].useFirstLayerAsMaks) ? firstLayerValue : 1;
                elevation += noiseFilters[i].Evaluate(pointOnUnitSphere) * mask;
            }
        }

        return pointOnUnitSphere * shapeSettings.planetRadius * (1+elevation);
    }
}
