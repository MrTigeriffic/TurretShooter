using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{

    [SerializeField] float speed;

    public Transform Reticle;
    Transform crossTop;
    Transform crossBottom;
    Transform crossLeft;
    Transform crossRight;

    float reticleStartPoint;
    // Start is called before the first frame update
    void Start()
    {
        crossTop = Reticle.Find("Cross/Top").transform;
        crossLeft = Reticle.Find("Cross/Left").transform;
        crossRight = Reticle.Find("Cross/Right").transform;
        crossBottom = Reticle.Find("Cross/Bottom").transform;

        reticleStartPoint = crossTop.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Reticle.transform.position = Vector3.Lerp(Reticle.transform.position, screenPos, speed * Time.deltaTime);
    }
}
