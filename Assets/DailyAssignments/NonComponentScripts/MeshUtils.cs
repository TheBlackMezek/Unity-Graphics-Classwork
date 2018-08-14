using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshUtils {

    #region Extent Getters
    public static float MaxWidth(Mesh mesh)
    {
        float ret = float.MinValue;
        foreach(Vector3 v in mesh.vertices)
        {
            if(v.x > ret)
            {
                ret = v.x;
            }
        }
        return ret;
    }

    public static float MinWidth(Mesh mesh)
    {
        float ret = float.MaxValue;
        foreach (Vector3 v in mesh.vertices)
        {
            if (v.x < ret)
            {
                ret = v.x;
            }
        }
        return ret;
    }

    public static float MaxHeight(Mesh mesh)
    {
        float ret = float.MinValue;
        foreach (Vector3 v in mesh.vertices)
        {
            if (v.y > ret)
            {
                ret = v.y;
            }
        }
        return ret;
    }

    public static float MinHeight(Mesh mesh)
    {
        float ret = float.MaxValue;
        foreach (Vector3 v in mesh.vertices)
        {
            if (v.y < ret)
            {
                ret = v.y;
            }
        }
        return ret;
    }

    public static float MaxDepth(Mesh mesh)
    {
        float ret = float.MinValue;
        foreach (Vector3 v in mesh.vertices)
        {
            if (v.z > ret)
            {
                ret = v.z;
            }
        }
        return ret;
    }

    public static float MinDepth(Mesh mesh)
    {
        float ret = float.MaxValue;
        foreach (Vector3 v in mesh.vertices)
        {
            if (v.z < ret)
            {
                ret = v.z;
            }
        }
        return ret;
    }

    public static void Extents(Mesh mesh, out Vector3 max, out Vector3 min)
    {
        max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
        min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

        foreach (Vector3 v in mesh.vertices)
        {
            if (v.x > max.x)
            {
                max.x = v.x;
            }
            if (v.x < min.x)
            {
                min.x = v.x;
            }
            if (v.y > max.y)
            {
                max.y = v.y;
            }
            if (v.y < min.y)
            {
                min.y = v.y;
            }
            if (v.z > max.z)
            {
                max.z = v.z;
            }
            if (v.z < min.z)
            {
                min.z = v.z;
            }
        }
    }
    #endregion

    public static float ExtentVolume(Mesh mesh)
    {
        Vector3 max, min;
        Extents(mesh, out max, out min);

        return (max.x - min.x) * (max.y - min.y) * (max.z - min.z);
    }

    public static Vector3 SmallestExtents(Mesh mesh)
    {
        Vector3 max, min;
        Extents(mesh, out max, out min);

        Vector3 extentSize = new Vector3(max.x - min.x, max.y - min.y, max.z - min.z);

        Vector3 ret = Vector3.one;
        if(extentSize.x > extentSize.y || extentSize.x > extentSize.z)
        {
            ret.x = 0;
        }
        if (extentSize.y > extentSize.x || extentSize.y > extentSize.z)
        {
            ret.y = 0;
        }
        if (extentSize.z > extentSize.y || extentSize.z > extentSize.x)
        {
            ret.z = 0;
        }

        return ret;
    }

    public static Vector3 Center(Mesh mesh)
    {
        Vector3 max, min;
        Extents(mesh, out max, out min);

        return new Vector3(min.x + (max.x - min.x) / 2.0f,
                           min.y + (max.y - min.y) / 2.0f,
                           min.z + (max.z - min.z) / 2.0f);
    }

}
