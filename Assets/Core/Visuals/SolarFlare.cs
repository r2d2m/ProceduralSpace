using UnityEngine;
using System.Collections;

public class SolarFlare : MonoBehaviour {

    [Tooltip("How big flare is")]
    public float flareSize = 80;
    [Tooltip("How fast smooth flare appears or disappers")]
    public float disappearingSmoothness = 0.00005f;
    [Tooltip("How fast flare disappear in the sector")]
    public float disappearingInChunk = 0f;
    [Tooltip("How fast flare disappear out of the sector")]
    public float disappearingOutChunk = 0.01f;
    [Tooltip("How close camera has to be to the flare to disappers")]
    public float closeSeen = 3000;
    [Tooltip("How far camera has from the flare to disappers")]
    public float farSeen = 100000;

	private Transform _cam;
    private Material _mat;
    private bool inSector = true;

	void Start () {
		_cam = GlobalSettings.singleton.mainCamera.transform;
        MeshRenderer mr = GetComponent<MeshRenderer>() as MeshRenderer;
        _mat = mr.material;
    }
	
	void Update () {
        transform.LookAt(_cam, _cam.up);
        float distance = Vector3.Distance(_cam.transform.position, transform.position);
        float factor = Mathf.Pow(500 / distance, disappearingInChunk);
        transform.localScale = new Vector3(factor * flareSize, factor * flareSize, 1);

        float colorFactor;
        if (inSector)
        {
            colorFactor = Mathf.Clamp(disappearingSmoothness * (distance - closeSeen), 0.0f, 0.5f);
            Color flareColor = new Color(_mat.GetColor("_TintColor").r, _mat.GetColor("_TintColor").g, _mat.GetColor("_TintColor").b, colorFactor);
            _mat.SetColor("_TintColor", flareColor);
        }
        else
        {
            Color flareColor = new Color(_mat.GetColor("_TintColor").r, _mat.GetColor("_TintColor").g, _mat.GetColor("_TintColor").b, 0);
            _mat.SetColor("_TintColor", flareColor);
        }

        if (distance > farSeen)
        {
            inSector = false;
        }
        else
        {
            inSector = true;
        }
    }
}
