using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Tile : MonoBehaviour {
    [SerializeField] public Vector2 position;

    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;

    
    void Awake(){
        _renderer.sortingLayerName = "Tiles"; // force it to render first

        position = this.transform.position;
    }
    public void Init(bool isOffset) {
        // is it offset? choose color
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }
 
}
