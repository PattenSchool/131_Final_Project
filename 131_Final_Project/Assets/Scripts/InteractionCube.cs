using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCube : MonoBehaviour
{
    // Sets gameobjects to detect and move to, as well as rigidbody and color
    private GameObject _GoToCube;
    private GameObject _InteractionObject;
    private Rigidbody _myRigidBody;
    private Color _currentColor;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Renderer>().material.color = Color.white;

        // Sets variables to current gameobjects
        _GoToCube = GameObject.FindGameObjectWithTag("MoveTo");
        _InteractionObject = GameObject.FindGameObjectWithTag("Interaction");
        _myRigidBody = gameObject.GetComponent<Rigidbody>();

        // Prints instructions on how to play game
        print("Hi! Press E to move the cube near you and change its color!");
        print("Or Press R to open the menu to save and load!");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Searches for "E" input, changes color on initial press and adds force when holding "E"
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _InteractionObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeColor();
            }
            else if (Input.GetKey(KeyCode.E))
            {
                _myRigidBody.AddForce((_GoToCube.transform.position - gameObject.transform.position) * force);
            }
        }
    }

    // Sets currentColor and changes current object to random color
    public void ChangeColor()
    {
        _currentColor = Random.ColorHSV();
        gameObject.GetComponent<Renderer>().material.color = _currentColor;
    }

    // Saves the cube's location and color
    public void SaveCube()
    {
        SaveData.SaveCubeLocation(gameObject.transform.position);
        SaveData.SaveCubeColor(_currentColor);
    }

    // Loads the cube's location and color from save
    public void LoadCube()
    {
        // Moves the cube to the saved location
        CubeLocation data = SaveData.LoadCubeLocation();
        gameObject.transform.position = new Vector3(data.Cube[0], data.Cube[1], data.Cube[2]);

        CubeColorData colorData = SaveData.LoadCubeColor();
        gameObject.GetComponent<Renderer>().material.color = new Color(colorData.CubeColor[0],
            colorData.CubeColor[1], colorData.CubeColor[2], colorData.CubeColor[3]);
    }
}
