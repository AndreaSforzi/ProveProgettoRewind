using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    PlayableDirector director;
    [SerializeField] GameObject player;
    [SerializeField] RadialMenu menu;

    public double speedReproduction;

    // Start is called before the first frame update
    void Start()
    {
        director = gameObject.GetComponent<PlayableDirector>();
        speedReproduction = 1;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0 )
            speedReproduction += 0.2;

        if (Input.GetAxis("Mouse ScrollWheel") < 0 )
            speedReproduction -= 0.2;

        if (Input.GetKeyDown(KeyCode.X))
            speedReproduction = 1;
        if (Input.GetKeyDown(KeyCode.Z))
            speedReproduction = 0;

        if (Input.GetKeyDown(KeyCode.I))
            menu.Open();



        if (speedReproduction!=0)
        {
            director.Play();
            director.time += Time.deltaTime * speedReproduction;

            if (director.time < 0)
                director.time = director.initialTime;

            if (director.time > director.duration)
                director.time = director.duration;

        }
        else
            director.Pause();

        float horizontal = Input.GetAxis("Horizontal");
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal*3, player.GetComponent<Rigidbody2D>().velocity.y);
    }
}
