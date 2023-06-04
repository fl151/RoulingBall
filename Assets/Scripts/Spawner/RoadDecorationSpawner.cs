using UnityEngine;

public class RoadDecorationSpawner : MonoBehaviour
{
    private void Decorate(PieceOfRoad piece)
    {
        if(piece is PieceAfterFinish)
        {
            DecorateAfterFinish(piece as PieceAfterFinish);
        }
        else
        {
            DecorateRoad(piece);
        }
    }

    private void DecorateAfterFinish(PieceAfterFinish piece)
    {

    }

    private void DecorateRoad(PieceOfRoad piece)
    {

    }
}
