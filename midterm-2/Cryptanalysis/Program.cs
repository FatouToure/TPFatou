using System;

namespace Cryptanalysis
{
internal static class Program
{
    private static void Main()
    {
        // Put your tests here.
        
        Console.WriteLine(Tools.Extract("ABCDEFGHIJKLMNO", 5, 3));
        Test();
    }

    private static void Test()
    {
        Test_Modulus_PositivePositive();
        Test_Modulus_NegativePositive();
        Test_Modulus_PositiveNegative();
        Test_Modulus_NegativeNegative();

        Test_RotChar_LowerCase();
        Test_RotChar_UpperCase();
        Test_RotChar_PositiveWrapping();
        Test_RotChar_NegativeWrapping();
        Test_RotChar_OtherChar();
        
        Console.WriteLine("All tests passed successfully.");
    }
    private static void Test_Modulus_PositivePositive()
    {
        AssertEq(1, Tools.Modulus(4, 3));
    }
    
    private static void Test_Modulus_NegativePositive()
    {
        AssertEq(2, Tools.Modulus(-4, 3));
    }
    
    private static void Test_Modulus_PositiveNegative()
    {
        AssertEq(1, Tools.Modulus(4, -3));
    }

    private static void Test_Modulus_NegativeNegative()
    {
        AssertEq(2, Tools.Modulus(-4, -3));
    }

    private static void Test_RotChar_LowerCase()
    {
        AssertEq('k', Tools.RotChar('g', 4));
    }
    
    private static void Test_RotChar_UpperCase()
    {
        AssertEq('K', Tools.RotChar('G', 4));
    }
    
    private static void Test_RotChar_PositiveWrapping()
    {
        AssertEq('c', Tools.RotChar('x', 5));
    }
    
    private static void Test_RotChar_NegativeWrapping()
    {
        AssertEq('v', Tools.RotChar('f', -10));
    }
    
    private static void Test_RotChar_OtherChar()
    {
        AssertEq('3', Tools.RotChar('3', 4));
    }

    private static void AssertEq<T>(T expected, T actual)
    {
        if (!Equals(expected, actual))
            throw new Exception($"Test failed: expecting {expected}, got {actual}.");
    }
}
}