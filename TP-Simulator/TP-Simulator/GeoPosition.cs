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


    }
}
