using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StarClassification {

    //Random
    public char StarClass;

    //Unknown
    [Tooltip("Solar mass (M☉), the mass of the Sun")]
    public float SolarMass;
    [Tooltip("Solar radius (R☉), the radius of the Sun (109 x R⊕)")]
    public float SolarRadius;
    [Tooltip("Luminosity(L☉), the luminosity of the Sun")]
    public float Luminosity;
    [Tooltip("Kelvin (K), 0 Kelvin is -273.15 Celsius")]
    public float Temperature;
    [Tooltip("StarColor")]
    public Color32 StarColor;

    public void CalculateClassification(char StarClass)
    {
        if(StarClass == 'M')
        {
            Temperature = Random.Range(2400, 3700);
            StarColor = new Color32(255, 69, 0, 255);
            SolarMass = Random.Range(0.08f, 0.45f);
            SolarRadius = Random.Range(0.4f, 0.7f);
            Luminosity = Random.Range(0.05f, 0.08f);
            this.StarClass = StarClass;
        }
        if(StarClass == 'K')
        {
            Temperature = Random.Range(3700, 5200);
            StarColor = new Color32(255, 165, 0, 255);
            SolarMass = Random.Range(0.45f, 0.8f);
            SolarRadius = Random.Range(0.7f, 0.96f);
            Luminosity = Random.Range(0.08f, 0.6f);
            this.StarClass = StarClass;
        }
        if(StarClass == 'G')
        {
            Temperature = Random.Range(5200, 6000);
            StarColor = new Color32(255, 255, 0, 255);
            SolarMass = Random.Range(0.8f, 1.04f);
            SolarRadius = Random.Range(0.96f, 1.15f);
            Luminosity = Random.Range(0.6f, 1.5f);
            this.StarClass = StarClass;
        }
        if(StarClass == 'F')
        {
            Temperature = Random.Range(6000, 7500);
            StarColor = new Color32(255, 255, 90, 255);
            SolarMass = Random.Range(1.04f, 1.4f);
            SolarRadius = Random.Range(1.15f, 1.4f);
            Luminosity = Random.Range(1.5f, 5f);
            this.StarClass = StarClass;
        }
        if(StarClass == 'A')
        {
            Temperature = Random.Range(7500, 10000);
            StarColor = new Color32(255, 255, 160, 255);
            SolarMass = Random.Range(1.4f, 2.1f);
            SolarRadius = Random.Range(1.4f, 1.8f);
            Luminosity = Random.Range(5, 25);
            this.StarClass = StarClass;
        }
        if(StarClass == 'B')
        {
            Temperature = Random.Range(10000, 30000);
            StarColor = new Color32(173, 216, 230, 255);
            SolarMass = Random.Range(2.1f, 16f);
            SolarRadius = Random.Range(1.8f, 6.6f);
            Luminosity = Random.Range(25, 30000);
            this.StarClass = StarClass;
        }
        if(StarClass == 'O')
        {
            Temperature = Random.Range(30000, 50000);
            StarColor = new Color32(0, 160, 255, 255);
            SolarMass = Random.Range(16f, 30f);
            SolarRadius = Random.Range(6.6f, 10f);
            Luminosity = Random.Range(30000, 50000);
            this.StarClass = StarClass;
        }
    }
}