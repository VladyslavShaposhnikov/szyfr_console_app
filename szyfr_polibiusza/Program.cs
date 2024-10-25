using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

string alfabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż"; // length = 35

char[,] tab = RandomKeyGeneration(alfabet);

Console.WriteLine("Tekst do zaszyfrowania/deszyfrowania");
string? input = Console.ReadLine();
string toChange = input.ToLower().Trim();

string result = "";

for (int i = 0; i < toChange?.Length; i++)
{
    if (alfabet.Contains(toChange[i]))
    {
        result += FindInt(toChange[i]); // replace chars with ints
    }
}

int y = 4; // random number
int z = 29586034; // random number

long? cipher = Cipher(result); // addition modifying ints

if (cipher is null)
{
    return;
}

string backToNormal = GetStringOfInts(cipher.Value);

BackToNormalWords(backToNormal);


// test code: add each element from random generated key to the string; convert chars to int; edd all chars in both strings; check if results are equal -------------------
// uncomment to see array in console

//string res = "";
//int res1 = 0;
//int res2 = 0;

//for (int i = 0; i < tab.GetLength(0); i++)
//{
//    for (int j = 0; j < tab.GetLength(1); j++)
//    {
//        Console.Write(tab[i, j] + " ");
//        res += tab[i, j];
//    }
//    Console.WriteLine();
//}

//for (int i = 0; i < alfabet.Length; i++)
//{
//    res1 += alfabet[i];
//    res2 += res[i];
//}

//Console.WriteLine(res1 == res2);
//Console.WriteLine(res1 + " = " + res2);

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------


// opposide to Cipher function
string GetStringOfInts(long unknown)
{
    long known = unknown - z;
    known /= y;
    known /= 2;
    return known.ToString();
}

// make more complicated number and check OverflowException
long? Cipher(string result)
{
    long x;
    long unknown;

    try
    {
        checked
        {
            x = long.Parse(result);
            unknown = x * 2;
            unknown *= y;
            unknown += z;
            return unknown;
        }
    }
    catch (OverflowException)
    {
        Console.WriteLine("too long secret...");
        return null;
    }
}

// function turn ints into a normal worlds
void BackToNormalWords(string toNorm)
{
    string toNormal = "";
    for (int i = 0; i < toNorm.Length; i += 2)
    {
        int one = int.Parse(toNorm[i].ToString());
        int two = int.Parse(toNorm[i + 1].ToString());
        toNormal += tab[--one, --two];
    }
    Console.WriteLine("deszyfr: " + toNormal);
}

// function that replace char with 2 numbers: nr. of row and nr. of column
string FindInt(char ch)
{
    string resultStr = "";

    for (int i = 0; i < tab.GetLength(0); i++)
    {
        for (int j = 0; j < tab.GetLength(1); j++)
        {
            if (ch == tab[i, j])
            {
                resultStr += (i + 1);
                resultStr += (j + 1);
                return resultStr;
            }
        }
    }
    return resultStr;
}

// Random key generation function (for 2 demention array 5x7)
char[,] RandomKeyGeneration(string alf)
{
    char[,] tabKey = new char[5, 7];

    char[] charArr = alf.ToCharArray();

    Random rand = new Random();

    int alfLength = alf.Length;

    for (int i = 0; i < tabKey.GetLength(0); i++)
    {
        for (int j = 0; j < tabKey.GetLength(1); j++)
        {
            char insert = charArr[rand.Next(0, alfLength)]; // random element

            MoveIndexInArray(charArr, insert); // moving selected element to the end of array

            alfLength--; // decrease length by 1 (to not select this element in next iteration)

            tabKey[i, j] = insert;


        }
    }

    return tabKey;
}

// function to move element which was selected randomly to the end of the array (to not take it again)
void MoveIndexInArray(char[] charArr, char insertedChar)
{
    int moveIndex = Array.IndexOf(charArr, insertedChar);
    char temp = charArr[moveIndex];

    for (int item = moveIndex; item < charArr.Length - 1; item++)
    {
        charArr[item] = charArr[item + 1];
    }

    charArr[charArr.Length - 1] = temp;
}
