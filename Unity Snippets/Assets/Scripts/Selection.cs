using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Selection
{
    static List<GameObject> PickObjectsInRect(List<GameObject> selectables, float left, float top, float right, float bottom, Camera camera = null)
    {
        List<GameObject> selected = new List<GameObject>();
        if (camera == null) camera = Camera.main;

        Ray bottomLeft = camera.ScreenPointToRay(new Vector3(left, bottom));
        Ray topLeft = camera.ScreenPointToRay(new Vector3(left, top));
        Ray topRight = camera.ScreenPointToRay(new Vector3(right, top));
        Ray bottomRight = camera.ScreenPointToRay(new Vector3(right, bottom));

        Plane[] planes = new Plane[5];
        planes[0].Set3Points(topLeft.GetPoint(3), bottomLeft.GetPoint(3), bottomRight.GetPoint(3)); // front
        planes[1].Set3Points(topLeft.origin, topRight.origin, topRight.GetPoint(100)); // top
        planes[2].Set3Points(topLeft.origin, topLeft.GetPoint(100), bottomLeft.GetPoint(100)); //left
        planes[3].Set3Points(bottomLeft.origin, bottomLeft.GetPoint(100), bottomRight.GetPoint(100));//bottom
        planes[4].Set3Points(topRight.origin, bottomRight.GetPoint(100), topRight.GetPoint(100)); //right

        foreach (GameObject go in selectables)
        {
            if (go.TryGetComponent<Collider>(out var collider))
            {
                if (GeometryUtility.TestPlanesAABB(planes, collider.bounds))
                {
                    selected.Add(go);
                }
            }
        }
        return selected;
    }
}