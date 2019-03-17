using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSettings : MonoBehaviour {

    public static GlobalSettings singleton;

    public GameObject mainCamera;

    [Header("Time")]
    public float TimeFlow = 1;
    public Text TimeFlow_Text;

    [Header("Orbits")]
    public bool Orbits = true;

    [Header("DistanceRendering")]
    public float DistanceStarsRadiusRelativeToCamera = 1000;

    [Header("Primitives")]
    public StarVisuals starVisuals;

    private void Awake()
    {
        Random.seed = 0;
        singleton = this;
    }

    private void Update()
    {
        ChangeTimeFlow();
        ShowHideOrbits();
    }

    private void ShowHideOrbits()
    {
        if(Input.GetKeyDown(KeyCode.O) && Orbits)
        {
            Orbits = false;
        }
        else if(Input.GetKeyDown(KeyCode.O) && !Orbits)
        {
            Orbits = true;
        }
    }

    private void ChangeTimeFlow()
    {
        if (Input.GetKeyDown(KeyCode.Equals) && TimeFlow >= 1 && TimeFlow < 1000000)
        {
            TimeFlow *= 10;
            TimeFlow_Text.text = "TimeFlow: " + TimeFlow;
        }
        if (Input.GetKeyDown(KeyCode.Minus) && TimeFlow <= -1 && TimeFlow > -1000000)
        {
            TimeFlow *= 10;
            TimeFlow_Text.text = "TimeFlow: " + TimeFlow;
        }
        if (Input.GetKeyDown(KeyCode.Minus) && TimeFlow == 0)
        {
            TimeFlow = -1;
            TimeFlow_Text.text = "TimeFlow: -1";
        }
        if (Input.GetKeyDown(KeyCode.Minus) && TimeFlow == 1)
        {
            TimeFlow = 0;
            TimeFlow_Text.text = "TimeFlow: Stopped";
        }
        if (Input.GetKeyDown(KeyCode.Minus) && TimeFlow > 1)
        {
            TimeFlow /= 10;
            TimeFlow_Text.text = "TimeFlow: " + TimeFlow;
        }
        if (Input.GetKeyDown(KeyCode.Equals) && TimeFlow == 0)
        {
            TimeFlow = 1;
            TimeFlow_Text.text = "TimeFlow: 1";
        }
        if (Input.GetKeyDown(KeyCode.Equals) && TimeFlow == -1)
        {
            TimeFlow = 0;
            TimeFlow_Text.text = "TimeFlow: Stopped";
        }
        if (Input.GetKeyDown(KeyCode.Equals) && TimeFlow < -1)
        {
            TimeFlow /= 10;
            TimeFlow_Text.text = "TimeFlow: " + TimeFlow;
        }
    }
}

[System.Serializable]
public struct StarVisuals
{
    [Header("Mesh")]
    public Mesh starMesh;

    [Header("Materials")]
    public Material ClassM_mat;
    public Material ClassK_mat;
    public Material ClassG_mat;
    public Material ClassF_mat;
    public Material ClassA_mat;
    public Material ClassB_mat;
    public Material ClassO_mat;

    [Header("Flares")]
    public GameObject ClassM_flare;
    public GameObject ClassK_flare;
    public GameObject ClassG_flare;
    public GameObject ClassF_flare;
    public GameObject ClassA_flare;
    public GameObject ClassB_flare;
    public GameObject ClassO_flare;

    [Header("Particles")]
    public GameObject ClassM_particle;
    public GameObject ClassK_particle;
    public GameObject ClassG_particle;
    public GameObject ClassF_particle;
    public GameObject ClassA_particle;
    public GameObject ClassB_particle;
    public GameObject ClassO_particle;

    [Header("Atmospheres")]
    public GameObject ClassM_atm;
    public GameObject ClassK_atm;
    public GameObject ClassG_atm;
    public GameObject ClassF_atm;
    public GameObject ClassA_atm;
    public GameObject ClassB_atm;
    public GameObject ClassO_atm;


    public Material GetMaterialByClass(char starClass)
    {
        if (starClass == 'M')
        {
            return ClassM_mat;
        }
        if (starClass == 'K')
        {
            return ClassK_mat;
        }
        if (starClass == 'G')
        {
            return ClassG_mat;
        }
        if (starClass == 'F')
        {
            return ClassF_mat;
        }
        if (starClass == 'A')
        {
            return ClassA_mat;
        }
        if (starClass == 'B')
        {
            return ClassB_mat;
        }
        if (starClass == 'O')
        {
            return ClassO_mat;
        }

        return null;
    }

    public GameObject GetFlareByClass(char starClass)
    {
        if (starClass == 'M')
        {
            return ClassM_flare;
        }
        if (starClass == 'K')
        {
            return ClassK_flare;
        }
        if (starClass == 'G')
        {
            return ClassG_flare;
        }
        if (starClass == 'F')
        {
            return ClassF_flare;
        }
        if (starClass == 'A')
        {
            return ClassA_flare;
        }
        if (starClass == 'B')
        {
            return ClassB_flare;
        }
        if (starClass == 'O')
        {
            return ClassO_flare;
        }

        return null;
    }

    public GameObject GetParticleByClass(char starClass)
    {
        if (starClass == 'M')
        {
            return ClassM_particle;
        }
        if (starClass == 'K')
        {
            return ClassK_particle;
        }
        if (starClass == 'G')
        {
            return ClassG_particle;
        }
        if (starClass == 'F')
        {
            return ClassF_particle;
        }
        if (starClass == 'A')
        {
            return ClassA_particle;
        }
        if (starClass == 'B')
        {
            return ClassB_particle;
        }
        if (starClass == 'O')
        {
            return ClassO_particle;
        }

        return null;
    }

    public GameObject GetAtmosphereByClass(char starClass)
    {
        if (starClass == 'M')
        {
            return ClassM_atm;
        }
        if (starClass == 'K')
        {
            return ClassK_atm;
        }
        if (starClass == 'G')
        {
            return ClassG_atm;
        }
        if (starClass == 'F')
        {
            return ClassF_atm;
        }
        if (starClass == 'A')
        {
            return ClassA_atm;
        }
        if (starClass == 'B')
        {
            return ClassB_atm;
        }
        if (starClass == 'O')
        {
            return ClassO_atm;
        }

        return null;
    }

}