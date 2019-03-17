using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClassification : MonoBehaviour {

    //Random
    [Tooltip ("Astronomical unit (AU), Earth distance from Sun is 1 AU")]
    public float DistanceFromStar;
    [Tooltip("Earth mass (M⊕), the mass of the Earth")]
    public float EarthMass;
    [Tooltip("Earth radius (R⊕), the radius of the Earth")]
    public float EarthRadius;
    [Tooltip("Atmosphere (Atm), Earth is 1 atm")]
    public float AtmosphericPressure;

    //Unknown
    [Tooltip ("Kelvin (K), 0 Kelvin is -273.15 Celsius")]
    public float Temperature;

}
