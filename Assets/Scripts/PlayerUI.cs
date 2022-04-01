using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    
    public Slider ultiSlider;
    PlayerMovement player;
    public Slider[] sliders;

    void Awake()
    {
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        ChangeUltiPosition();

        ultiSlider.gameObject.SetActive(ultiSlider.value > 0);
    }

    void ChangeUltiPosition()
    {
        float midPoint = (player.maxBoundsX + player.minBoundsX) / 2;
        
        sliders[0].gameObject.SetActive(transform.position.x < midPoint);
        
        sliders[1].gameObject.SetActive(transform.position.x >= midPoint);

        sliders[0].value = ultiSlider.value;
        sliders[1].value = ultiSlider.value;
    }


    public void AddUltiPoint(int point)
    {
        ultiSlider.value += point; 
    }

    public void ResetSliderPoint()
    {
        ultiSlider.value = 0;
    }
}
