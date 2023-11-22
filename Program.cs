
using System.Formats.Asn1;

string[] osvenyTomb = File.ReadAllLines("osvenyek.txt");
string dobasokSzoveg = File.ReadAllText("dobasok.txt");
string[]dobasokTomb = dobasokSzoveg.Split(' ');

Console.WriteLine("2. feladat");
Console.WriteLine($"A dobások száma {dobasokTomb.Count()}");
Console.WriteLine($"Az ösvények száma: {osvenyTomb.Count()}");


int asd = 0;

for (int i = 0; i < osvenyTomb.Length; i++)
{
	if (osvenyTomb[i].Length > osvenyTomb[asd].Length)
	{
		asd = i;
	}

}
Console.WriteLine("3. feladat");
Console.WriteLine($"Az egyik leghosszabb a(z) {asd}. ösvény, hossza: {osvenyTomb[asd].Length }");

Console.WriteLine("4.feladat");
Console.WriteLine("Adja meg egy ösvény sorszámát! ");
int osvenySorszama = Convert.ToInt32(Console.ReadLine());
int jatekosokSzama = 0;
while (jatekosokSzama<2||jatekosokSzama>5)
{
    Console.WriteLine("Adja meg a játékosok sorszámát!");
    jatekosokSzama  = Convert.ToInt32(Console.ReadLine());
}

int mSzamlalo=0;
int vSzamlalo=0;
int eSzamlalo = 0;
StreamWriter sw = new StreamWriter("kulonleges.txt");
int index= 0;
foreach (char item in osvenyTomb[osvenySorszama-1])
{
	if (item=='M')
	{
		mSzamlalo++;
	}
	if (item =='V')
	{
		vSzamlalo++;
        sw.Write($"{index}:{item}\n");
    }
	if (item == 'E')
	{
		eSzamlalo++;
        sw.Write($"{index}:{item}\n");
    }
	index++;
}
Console.WriteLine($"M: {mSzamlalo} darab");
Console.WriteLine($"V: {vSzamlalo} darab");
Console.WriteLine($"E: {eSzamlalo} darab");

Console.WriteLine("7. feladat");
int[] dobasok = new int[jatekosokSzama];
int szamlalo = 0;
int korszamlalo = 1;
Console.WriteLine("7. feladat");
foreach (var dobott in dobasokTomb)
{
    dobasok[szamlalo] += int.Parse(dobott);
    szamlalo++;
    if (szamlalo == jatekosokSzama)
	{
		szamlalo = 0;
	}

	if (dobasok[szamlalo]>=osvenyTomb.Length)
	{
        Console.WriteLine($"A játék a(z) {korszamlalo}. körben fejeződött be. A legtávolabb jutó sorszáma: {szamlalo+1}");

        break;
    }
	korszamlalo++;
}
int[] dobasokSpecialis = new int[jatekosokSzama];
szamlalo = 0;
bool hozzaad = true;
foreach (var dobott in dobasokTomb)
{


	if (osvenyTomb[osvenySorszama][dobasokSpecialis[szamlalo] + int.Parse(dobott)] == 'V')
	{
		szamlalo++;

		hozzaad = false;
		continue;

	}
	if (osvenyTomb[osvenySorszama][dobasokSpecialis[szamlalo] + int.Parse(dobott)] == 'E')
	{
		dobasokSpecialis[szamlalo] += int.Parse(dobott);
	}
   
	dobasokSpecialis[szamlalo] += int.Parse(dobott);
	if (hozzaad)
	{
		szamlalo++;
	} 


	if (szamlalo == jatekosokSzama)
	{
		szamlalo = 0;
	}

	if (dobasokSpecialis[szamlalo] >= osvenyTomb.Length)
	{
		int i = 1;
		foreach (var item in dobasokSpecialis)
		{
			Console.WriteLine($"{i}. játékos, {item}. mező");
			i++;
		};

		break;
	}
	hozzaad = true;

}


    sw.Close();