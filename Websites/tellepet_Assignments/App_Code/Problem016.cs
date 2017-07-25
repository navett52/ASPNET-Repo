/*<%--
    Evan Tellep
    Bill Nicholson
    ASP.NET
    1/25/2017
    Assignment01
    Create a page that solves a project euler problem of our choice
    Ref: http://stackoverflow.com/questions/4808612/how-to-split-a-number-into-individual-digits-in-c
--%>*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Numerics;

/// <summary>
/// Solving Project Euler 016
///     2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
///     What is the sum of the digits of the number 2^1000?
/// </summary>
public class Problem016
{
    public Problem016() { /*blank constructor*/ }

    /// <summary>
    /// The method to solve problem 016
    /// </summary>
    /// <returns>The answer</returns>
    public int Solve()
    {
        //declaring and instantiating a result to be returned
        int result = 0;
        //Declare a temp variable to be used in the loop
        int temp;
        //2^1000 is very big so we need to put it in a BigInt
        BigInteger num = new BigInteger(Math.Pow(2, 1000));
        BigInteger ten = new BigInteger(10);
        List<BigInteger> digits = new List<BigInteger>();
        //For some reason it's not possible to split on '' in c# so I had to do this
        //Ref in header*
        while (num > 0)
        {
            digits.Add(num % 10);
            num /= 10;
        }
        //For each digit convert it to an int then add it to the result
        foreach (BigInteger digit in digits)
        {
            temp = (int) digit;
            result += temp;
        }
        return result;
    }
}