using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] public int _width, _height;

    //[SerializeField] private GameObject _tileHolder;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Holder _holder;
    [SerializeField] private Transform _camera;

    private Dictionary<Vector2, Tile> _tiles;
    private Dictionary<Vector2, Holder> _holders;
    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
     float xIncrease = _tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
     float yIncrease = _tilePrefab.GetComponent<SpriteRenderer>().bounds.size.y; 
        _tiles = new Dictionary<Vector2, Tile>();
        _holders = new Dictionary<Vector2, Holder>();
        for (float x = 0; x < _width; x++)
        {
            float xPos = x * xIncrease;
            for (float y = 0; y < _height; y++)
            {
                float yPos = y * xIncrease;
                print(_tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x);
                var spawnTile = Instantiate(_tilePrefab, new Vector3(xPos, yPos), Quaternion.identity, this.transform);
                spawnTile.name = $"Tile {x} {y}";
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = spawnTile;
                
                var spawnHolder = Instantiate(_holder, new Vector3(x, y), Quaternion.identity,
                    spawnTile.GetComponent<Transform>());
                spawnHolder.name = $"Holder {x} {y}";
                
                _holders[new Vector2(x, y)] = spawnHolder;
              

            }

           
        }

       // _camera.transform.position = new Vector3((float) _width / 2 - 0.5f, (float) _height / 2 - 0.5f, -10);

    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
    public Holder GetHolderAtPosition(Vector2 pos)
    {
        if (_holders.TryGetValue(pos, out var holder))
        {
            return holder;
        }

        return null;
    }

}
