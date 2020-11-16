using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    private BoardGenerator _boardGenerator;
    private BoardMapper _boardMapper;
    private BoardController _boardController;

    

    private Hex[][] _board;

    [SerializeField]
    private BoardBlueprint _boardBlueprint;

    private void GenerateBoard()
    {
        _boardGenerator = GetComponent<BoardGenerator>();
        _board = _boardGenerator.GenerateBoard(_boardBlueprint);

        _boardMapper = new BoardMapper();
        _boardMapper.MapNeighbours(_board);
    }
    public BoardController GetBoardController()
    {
        if (_boardController != null)
        {
            return _boardController;
        }
        else
        {
            if(_board != null)
            {
                _boardController = new BoardController(_board);
                return _boardController;
            }
            else
            {
                GenerateBoard();
                _boardController = new BoardController(_board);
                return _boardController;
            }
        }
    }

    public Hex[][] GetBoard()
    {
        return _board;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(_board == null)
            {
                GenerateBoard();
                GetBoardController();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log($"{_board[1][1].ReturnTokken().name}");
            Debug.Log($"{_board[1][1].ReturnTokken().GetTokkenAction()}");
            
            _board[1][1].ReturnTokken().GetTokkenAction().TriggerBattleActions(_boardController);
        }
    }
}
