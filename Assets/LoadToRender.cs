using UnityEngine;

public class LoadToRender : MonoBehaviour {

    private Material starting_mat = null;
    private Mesh starting_mesh = null;
    private Model currentModel;

    public MeshFilter filter;
    public MeshRenderer obj_renderer;
    
    private void Start()
    {
        starting_mat = obj_renderer.material;
        starting_mesh = filter.mesh;
    }


    public void LoadModel(Model model)
    {
        currentModel = model;

        filter.mesh = model.mesh;
        obj_renderer.materials = new Material[] { model.material };
    }
	
}



public struct Model
{
    public Mesh mesh;
    public Material material;
}
