using System;
using UnityEngine;

public class Dragline : MonoBehaviour
{
    public LineRenderer line;
    public Color lineColor1;
    public Color lineColor2;
    private Vector3 lineStartPosition;
    [Range(0.1f,1f)] public float colorGradient=0.1f;

    private void Start()
    {
        line.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        EnableLine(transform.position);
    }

    private void OnMouseDrag()
    {
        UpdateLine(transform.position);
    }

    private void OnMouseUp()
    {
        DisableLine();
    }

    
    private void EnableLine(Vector3 startPosition)
    {
        line.SetPosition(0, startPosition);
        line.SetPosition(1, startPosition);
        lineStartPosition = startPosition;
        line.gameObject.SetActive(true);
		
    }

    private void DisableLine()
    {
        line.gameObject.SetActive(false);
    }

    private void UpdateLine(Vector3 endPosition)
    {
        line.SetPosition(1, endPosition);
        float relativeDistance = Vector3.Distance(lineStartPosition ,endPosition) * colorGradient;
        line.material.color = Color.Lerp(lineColor1, lineColor2, relativeDistance);

    }
}