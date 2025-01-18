using LeafyVersion3.Infrastructure.Model;

namespace LeafyVersion3.Services
{
    public class PointsCalculationService
    {
        public int CalculatePoints(string materialType, double Quantity)
        {
            int points = 0;

            switch (materialType.ToLower())
            {
                case "glass":
                    points = (int)(Quantity * 2);
                    break;

                case "metal":
                    points = (int)(Quantity * 4);
                    break;
                case "paper":
                    points = (int)(Quantity * 1);
                    break;
                case "plastic":
                    points = (int)(Quantity * 3);
                    break;
                default:
                    points = 0;
                    break;
            }

            return points;
        }
    }
}