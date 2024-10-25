using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

string alfabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż"; // length = 35

Console.WriteLine("naciśnij \"s\" żeby zaszyfrować, albo \"d\" żeby deszyfrować");
string? option = Console.ReadLine();
option?.ToLower().Trim();
Console.WriteLine("kod szyfru (większy od 0 mniejszy od 35)");
string? kodSzyfru = Console.ReadLine();
int.TryParse(kodSzyfru, out int result);
if (result >= alfabet.Length || result < 0)
{
    Console.WriteLine("Kod szyfru ma być większy od 0 i mniejszy 35 (ilość liter w alfabecie)");
    return;
}
Console.WriteLine("Tekst do zaszyfrowania/deszyfrowania");
string? toChange = Console.ReadLine();
toChange?.ToLower().Trim();


string res = "";
for (int i = 0; i < toChange?.Length; i++)
{
    int resultIndex;
    if (alfabet.Contains(toChange[i]))
    {
        int index = alfabet.IndexOf(toChange[i]);
        if(option == "s")
        {
            resultIndex = index + result;
            if (resultIndex >= alfabet.Length)
            {
                resultIndex -= alfabet.Length;
            }
        }
        else if (option == "d")
        {
            resultIndex = index - result;
            if (resultIndex < 0)
            {
                resultIndex += alfabet.Length;
            }
        }
        else
        {
            Console.WriteLine("Something went wrong:(");
            return;
        }
        res += alfabet[resultIndex];
    }
}
Console.WriteLine(res);