using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlock : MonoBehaviour
{
    private BuildingController _buildingController;

    private BuildingBlock _buildingBlock;

    private Renderer _renderer;

    private Material mat;

    private GameObject[] childGameObjects;

    public GameObject canvasHealthBar;

    public Color canNotBuildBlockColor;
    public Color canBuildColor;

    public float transparency;

    private void Start()
    {
        _buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();
        _buildingBlock = GetComponent<BuildingBlock>();

        childGameObjects = GetChildren(gameObject);

        _renderer = GetComponent<Renderer>();
        ChangeBuildBlockColor(canBuildColor, transparency);

    }

    private void Update()
    {
        if (!_buildingController.buildingMode)
        {
            ChangeBuildBlockColor(canBuildColor, 1f);
            canvasHealthBar.SetActive(true);
            Destroy(_buildingBlock);
        }
    }

    public void ChangeBuildBlockColor(Color newColor, float alpha)
    {
        if (_renderer != null)
        {
            mat = _renderer.material;

            mat.color = new Color(newColor.r, newColor.g, newColor.b, alpha);

            foreach (GameObject child in childGameObjects)
            {
                child.GetComponent<Renderer>().material.color = new Color(newColor.r, newColor.g, newColor.b, alpha);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Build"))
        {
            _buildingController.canNotBuildHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor, transparency);
        }
        if (collision.gameObject.CompareTag("Kaylo"))
        {
            _buildingController.canNotBuildHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor, transparency);
        }
        if (collision.gameObject.CompareTag("Bush"))
        {
            _buildingController.canNotBuildHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor, transparency);
        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            _buildingController.canNotBuildHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor, transparency);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _buildingController.canNotBuildHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor, transparency);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Build"))
        {
            _buildingController.canNotBuildHere = false;
            ChangeBuildBlockColor(canBuildColor, transparency);
        }
        if (collision.gameObject.CompareTag("Kaylo"))
        {
            _buildingController.canNotBuildHere = false;
            ChangeBuildBlockColor(canBuildColor, transparency);
        }
        if (collision.gameObject.CompareTag("Bush"))
        {
            _buildingController.canNotBuildHere = false;
            ChangeBuildBlockColor(canBuildColor, transparency);
        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            _buildingController.canNotBuildHere = false;
            ChangeBuildBlockColor(canBuildColor, transparency);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _buildingController.canNotBuildHere = false;
            ChangeBuildBlockColor(canBuildColor, transparency);
        }
    }

    GameObject[] GetChildren(GameObject parent)
    {
        // Get all child transforms of the parent
        Transform[] childrenTransforms = parent.GetComponentsInChildren<Transform>();

        // Create an array to store the child GameObjects
        GameObject[] childObjects = new GameObject[childrenTransforms.Length - 1]; // -1 to exclude the parent itself

        // Loop through the children and add them to the array
        int index = 0;
        foreach (Transform childTransform in childrenTransforms)
        {
            if (childTransform != parent.transform) // Exclude the parent itself
            {
                childObjects[index] = childTransform.gameObject;
                index++;
            }
        }

        return childObjects;
    }
}
