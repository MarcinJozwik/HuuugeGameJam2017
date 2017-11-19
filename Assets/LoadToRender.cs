using UnityEngine;
using UnityEngine.UI;
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


    public RawImage image;
    public Texture2D icon;
    private RenderTexture renderTarget;

    private void Start()
    {
        renderTarget = GetComponent<Camera>().targetTexture;
    }


    public void LoadModel(Model model, bool isHead)
    {
        currentModel = model;
        image.texture = renderTarget;
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

    public void LoadSprites()
    {
        image.texture = icon;
    }
	
}



public struct Model
{
    public Mesh mesh;
    public Material material;
}
