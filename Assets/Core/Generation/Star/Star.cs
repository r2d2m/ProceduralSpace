using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceMath;

public class Star : MonoBehaviour {

    public char classification;
    public StarClassification starClassification;

    private Transform _cam;

    private GameObject starFlare;
    private GameObject starAtmosphere;
    private GameObject starParticles;

    //DistanceRendering
    private float meshRenderDistance = 100f;

    public char Classification
    {
        get
        {
            return classification;
        }
        set
        {
            if (classification != value)
            {
                classification = value;
                CreateStar();
            }
        }
    }

    private void CreateStar()
    {
        if(starClassification == null)
        {
            starClassification = new StarClassification();
        }
        if(GetComponent<MeshFilter>().sharedMesh == null)
        {
            GetComponent<MeshFilter>().sharedMesh = GlobalSettings.singleton.starVisuals.starMesh;
        }
        GetComponent<MeshRenderer>().sharedMaterial = GlobalSettings.singleton.starVisuals.GetMaterialByClass(classification);

        starClassification.CalculateClassification(classification);
        gameObject.transform.localScale = new Vector3(starClassification.SolarRadius, starClassification.SolarRadius, starClassification.SolarRadius);

        //Flare
        if(starFlare == null)
        {
            starFlare = Instantiate(GlobalSettings.singleton.starVisuals.GetFlareByClass(classification), transform.position, Quaternion.identity);
            starFlare.transform.parent = transform;
        }

        starFlare.GetComponent<SolarFlare>().flareSize = gameObject.transform.localScale.x ;
        starFlare.GetComponent<SolarFlare>().closeSeen *= gameObject.transform.localScale.x;
        starFlare.GetComponent<SolarFlare>().disappearingSmoothness /= gameObject.transform.localScale.x;

        //Atmosphere
        if (starAtmosphere == null)
        {
            starAtmosphere = Instantiate(GlobalSettings.singleton.starVisuals.GetAtmosphereByClass(classification), transform.position, Quaternion.identity);
            starAtmosphere.transform.parent = transform;
            starAtmosphere.transform.localScale = new Vector3(1, 1, 1);
            starAtmosphere.SetActive(false);
        }

        GetComponent<MeshRenderer>().enabled = false;
        _cam = GlobalSettings.singleton.mainCamera.transform;
    }

    private void Update()
    {
        RenderStarDistance();
    }

    private void RenderStarDistance()
    {
        double distanceFromCamera = Vector3.Distance(transform.position, _cam.position);
        //mesh
        if (distanceFromCamera <= starFlare.GetComponent<SolarFlare>().closeSeen * meshRenderDistance && !GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().enabled = true;
            starAtmosphere.SetActive(true);
        }
        else if (distanceFromCamera > starFlare.GetComponent<SolarFlare>().closeSeen * meshRenderDistance && GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().enabled = false;
            starAtmosphere.SetActive(false);
        }

        starFlare.transform.position = SpaceMath.Math.PositionRelativeToRadius(transform.position, _cam.transform.position, GlobalSettings.singleton.DistanceStarsRadiusRelativeToCamera);
    }
}
