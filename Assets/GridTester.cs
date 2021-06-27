using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridTester : MonoBehaviour
{
    [SerializeField] private HeatMapGenericVisual heatMapGenericVisual;

    private BattleGrid<HeatMapGridObject> grid;

   private void Start()
    {
        grid = new BattleGrid<HeatMapGridObject>(20, 10, 8f, Vector3.zero, (BattleGrid<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y));
        heatMapGenericVisual.SetGrid(grid);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            HeatMapGridObject heatMapGridObject = grid.GetGridObject(position);
            if(heatMapGridObject != null)
            {
                heatMapGridObject.AddValue(5);
            }
        }
    }

    public class HeatMapGridObject
    {
        private const int MIN = 0;
        
        private const int MAX = 100;

        private BattleGrid<HeatMapGridObject> grid;
        private int x;
        private int y;
        public int value;

        public HeatMapGridObject(BattleGrid<HeatMapGridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void AddValue(int addValue)
        {
            value += addValue;
            value = Mathf.Clamp(value, MIN, MAX);
            grid.TriggerGridObectChanged(x, y);
        }

        public float GetValueNormalized()
        {
            return (float)value / MAX;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
