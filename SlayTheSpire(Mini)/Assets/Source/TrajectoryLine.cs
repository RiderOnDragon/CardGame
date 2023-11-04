using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private int _vertexCount;
    [SerializeField] private float _bendingRatioX;
    [SerializeField] private float _bendingRatioY;

    [SerializeField] private Vector2 _pointerOffset;

    private Vector2 _startPosition;

    public static TrajectoryLine Singleton { get; private set; }

    private void Awake()
    {
        if (Singleton is null)
            Singleton = this;
        else
            Destroy(gameObject);

        DisableLine();
    }

    public void EnableLine(Vector2 startPosition)
    {
        _startPosition = startPosition;
        gameObject.SetActive(true);
    }

    public void UpdateLine(Vector2 targetPosition)
    {
        Vector2 middlePosition = new Vector2((_startPosition.x + targetPosition.x) * _bendingRatioX, ((_startPosition.y + targetPosition.y) / _bendingRatioY));

        List<Vector3> linePoints = new List<Vector3>();

        for (float i = 0; i <= 1; i += (1f / _vertexCount))
        {
            var tangent1 = Vector3.Lerp(_startPosition, middlePosition, i);
            var tangent2 = Vector3.Lerp(middlePosition, targetPosition, i);

            var curve = Vector3.Lerp(tangent1, tangent2, i);

            linePoints.Add(curve);
        }

        _lineRenderer.positionCount = linePoints.Count;
        _lineRenderer.SetPositions(linePoints.ToArray());
    }

    public void DisableLine()
    {
        gameObject.SetActive(false);
    }
}
