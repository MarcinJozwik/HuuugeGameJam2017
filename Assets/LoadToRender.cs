using UnityEngine;

public class LoadToRender : MonoBehaviour {

    private Material starting_mat = null;
    private Mesh starting_mesh = null;
    public Model currentModel;

    public GameObject parent;
    public MeshFilter filter;
    public MeshRenderer obj_renderer;

    public GameObject headParent;
    public MeshFilter headFilter;
    public MeshRenderer headObj_renderer;

    private void Start()
    {
        starting_mat = obj_renderer.material;
        starting_mesh = filter.mesh;
    }


    public void LoadModel(Model model, bool isHead)
    {
        currentModel = model;

        if (isHead)
        {
            this.headFilter.mesh = model.mesh;
            this.headObj_renderer.materials = new Material[] {model.material};
            this.headParent.SetActive(true);
            this.parent.SetActive(false);
        }
        else
        {
            filter.mesh = model.mesh;
            obj_renderer.materials = new Material[] { model.material };
            this.headParent.SetActive(false);
            this.parent.SetActive(true);
        }
    }
	
}



public struct Model
{
    public Mesh mesh;
    public Material material;
}
