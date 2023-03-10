internal class KodePos
{
    enum Kelurahan
    {
        Batununggal,
        Kujangsari,
        Mengger,
        Wates,
        Cijaura,
        Jatisari,
        Margasari,
        Sekejati,
        Kebonwaru,
        Maleer,
        Samoja
    }

    private static int getKodePos_1302213089(Kelurahan inputKelurahan)
    {
        int[] outputKodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
        int inputInt = (int)inputKelurahan;
        return outputKodePos[inputInt];
    }

    private static void Main(string[] args)
    {
        Kelurahan kel = Kelurahan.Mengger;
        int kodepos = getKodePos_1302213089(kel);
        Console.WriteLine("Kelurahan " + kel + " memiliki kode pos : " + kodepos);
    }
}