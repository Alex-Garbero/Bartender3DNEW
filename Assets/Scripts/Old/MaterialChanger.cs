using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    private MeshRenderer render;
    public Material newMat;
    public Material newMat2;
    private Material original;
    // Start is called before the first frame update
    public void Awake()
    {
        render = this.GetComponent<MeshRenderer>();
        original = render.material;
    }

    // Update is called once per frame
    public void change()
    {
        render.material = newMat;
    }
    public void revert()
    {
        render.material = original;
    }
    public void confirm()
    {
        render.material = newMat2;
    }
}
