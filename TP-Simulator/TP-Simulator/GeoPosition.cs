using DotSpatial.Projections.Transforms;
using System;

namespace TP_Simulator
{
    static class GeoPosition
    {
        /// <summary>
        /// Convert the pos in lattitute and longitute
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string ConvertToDMS(int x, int y, int width, int height)
        {
            width = 1598;
            height = 908;

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
