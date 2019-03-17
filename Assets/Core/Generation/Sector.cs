using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spaceworks.Position;

public class Sector : MonoBehaviour {
    public int starsDensity = 1;

    private void Start()
    {
        GenerateStars();
    }

    private void GenerateStars () {
		for(int i = 0; i < starsDensity; i++)
        {
            char classtype = 'M';
            float percent = Random.value;

            if (percent > 0.5f)
            {
                classtype = 'M';
            }
            if (percent > 0.6f)
            {
                classtype = 'K';
            }
            if (percent > 0.7f)
            {
                classtype = 'G';
            }
            if (percent > 0.9f)
            {
                classtype = 'F';
            }
            if (percent > 0.99f)
            {
                classtype = 'A';
            }
            if (percent > 0.999f)
            {
                classtype = 'B';
            }
            if (percent > 0.9995f)
            {
                classtype = 'O';
            }

            Vector3 rndPos = RandomPointInSector(transform.localScale);

            GameObject star = new GameObject("Star");
            star.transform.parent = gameObject.transform;
            star.transform.localPosition = rndPos + transform.position;
            star.AddComponent<MeshFilter>();
            star.AddComponent<MeshRenderer>();
            star.AddComponent<Star>().Classification = classtype;
        }
    }

    private Vector3 RandomPointInSector(Vector3 size)
    {
        Vector3 center = new Vector3(0, 0, 0);

        return center + new Vector3(
           (Random.value - 0.5f) * size.x,
           (Random.value - 0.5f) * size.y,
           (Random.value - 0.5f) * size.z
        );
    }
}
