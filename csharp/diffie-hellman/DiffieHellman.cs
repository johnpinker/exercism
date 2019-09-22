using System;
using System.Numerics;


public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP) 
    {
        Random r = new Random();
        return new BigInteger(r.Next(1, (int)primeP));
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) 
    {
        return BigInteger.Pow(primeG, (int)privateKey) % primeP;
    }

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) 
    {
       return BigInteger.Pow(publicKey, (int)privateKey) % primeP;
    }
}