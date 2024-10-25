using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

string alfabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż"; // length = 35

char[,] tab = new char[5,7];

char[] charArray = alfabet.ToCharArray();

Random rand = new Random();

int alfabetLength = alfabet.Length;

for (int i = 0; i < tab.GetLength(0); i++)
{
    for (int j = 0; j < tab.GetLength(1); j++)
    {
        char insert = charArray[rand.Next(0, alfabetLength)];
        alfabetLength--;
        tab[i, j] = insert;

        MoveIndexInArray(charArray, insert);

    }
}

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
