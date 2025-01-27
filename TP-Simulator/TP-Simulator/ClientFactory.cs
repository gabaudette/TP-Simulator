﻿using System;

namespace TP_Simulator
{
    public sealed class ClientFactory
    {
        private static ClientFactory clientFactory;
        Random rnd = new Random(DateTime.Now.Millisecond);


        private ClientFactory() { }

        public static ClientFactory GetClientFactory()
        {
            if (clientFactory == null)
                clientFactory = new ClientFactory();
            return clientFactory;
        }
        /// <summary>
        /// Create a rescue team client
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Client CreateRescueTeam()
        {
            int[] pos = clientFactory.getRandomPos();
            return new RescueTeam(pos[0], pos[1]);
        }
        /// <summary>
        /// Create a fire client
        /// </summary>
        /// <param name="fireSpan"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Client CreateFire()
        {           
            int[] pos = clientFactory.getRandomPos();
            int fireSpan = clientFactory.getRandomNumber(1,4);
            return new Fire(fireSpan, pos[0],pos[1]);
        }
        /// <summary>
        /// Create a passenger client
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="airport"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Client CreatePassenger(Airport airport, Airport destination)
        {
            int amount = clientFactory.getRandomNumber(10, 50);

            return new Passenger(amount,airport,destination);
        }
        /// <summary>
        /// Create a marchandise client
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="airport"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Client CreateMarchandise(Airport airport, Airport destination)
        {
            int amount = clientFactory.getRandomNumber(10, 100);
            return new Marchandise(amount, airport, destination);
        }
        /// <summary>
        /// Create an obersver client
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Client CreateObserver()
        {
            int[] pos = clientFactory.getRandomPos();
            return new Observer(pos[0], pos[1]);
        }

        /// <summary>
        /// Return a random value
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int getRandomNumber(int min, int max)
        {
            return rnd.Next(min, max);
        }

        /// <summary>
        /// Return a random position
        /// </summary>
        /// <returns></returns>
        private int[] getRandomPos()
        {
            int[] tabPos = {rnd.Next(0, 926), rnd.Next(0, 500) };
            return tabPos;
        }
    }
}
