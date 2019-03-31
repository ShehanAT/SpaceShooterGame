using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Utils : MonoBehaviour
{
    //============================ Materials Functions ===========================\\
    // Returns a list of all Materials on this GameObject and its children
    public static Material[] GetAllMaterials(GameObject go)
    {
        var rends = go.GetComponentsInChildren<Renderer>();
        return (rends.Select(rend => rend.material).ToArray());
    }
}