using DotSpatial.Projections.Transforms;
using System;

namespace TP_Simulator
{
    static class GeoPosition
    {
        public static string ConvertToDMS(int x, int y, int width, int height)
        {
            double tempX = (double)(x * 180) / width - 90;
            double tempY = (double)(x * 180) / height - 90;

            double degX = Math.Floor(tempX);
            double degY = Math.Floor(tempY);

            double tempDegX = x - degX;
            double tempDegY = y - degY;

            double minX = Math.Abs(tempDegX * 60);
            double minY = Math.Abs(tempDegY * 60);

            Console.WriteLine($"'minX: {minX}, minY:{minY} X: {x}, Y: {y}");
            return null;
        }

        public static string getCoord(int x, int y)
        {
            int width = 1598;
            int height = 908;

            double degreFromMidX = Math.Abs(x - width / 2);
            double horizontalDegree = (degreFromMidX * 360) / width;
            double horizontalMin = (horizontalDegree - Math.Floor(horizontalDegree)) * 60;

            double degreFromMidY = Math.Abs(y - height / 2);
            double verticalDegree = (degreFromMidY * 360) / width;
            double verticalMin = (verticalDegree - Math.Floor(verticalDegree)) * 60;

            if ((x < width / 2) && (y < height / 2))
                return $"{Math.Floor(verticalDegree)}° {Math.Floor(verticalMin)} S, {Math.Floor(horizontalDegree)}° {Math.Floor(horizontalMin)} O";
            else if ((x > width / 2) && (y < height / 2))
                return $"{Math.Floor(verticalDegree)}° {Math.Floor(verticalMin)} N, {Math.Floor(horizontalDegree)}° {Math.Floor(horizontalMin)} E";
            else if ((x > width / 2) && (y > height / 2))
                return $"{Math.Floor(verticalDegree)}° {Math.Floor(verticalMin)} N, {Math.Floor(horizontalDegree)}° {Math.Floor(horizontalMin)} O";
            else 
                return $"{Math.Floor(verticalDegree)}° {Math.Floor(verticalMin)} S, {Math.Floor(horizontalDegree)}° {Math.Floor(horizontalMin)} E";
        }
    }
}
