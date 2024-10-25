using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

string alfabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż"; // length = 35

char[,] tab = RandomKeyGeneration(alfabet);

// test code: add each element from random generated key to the string; convert chars to int; edd all chars in both strings; check if results are equal
string res = ""; 
int res1 = 0;
int res2 = 0;

for (int i = 0; i < tab.GetLength(0); i++)
{
    for (int j = 0; j < tab.GetLength(1); j++)
    {
        Console.Write(tab[i, j] + " ");
        res += tab[i, j];
    }
    Console.WriteLine();
}

for (int i = 0; i < alfabet.Length; i++)
{
    res1 += (int)alfabet[i];
    res2 += (int)res[i];
}

Console.WriteLine(res1 == res2);
Console.WriteLine(res1 + " = " + res2);


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
